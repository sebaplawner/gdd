USE msdb ;
GO
EXEC dbo.sp_add_job
    @job_name = N'Cancelar reservas pasada una fecha' ;
GO
EXEC sp_add_jobstep
    @job_name = N'Cancelar reservas pasada una fecha',
    @step_name = N'Cancelar las reservas',
    @subsystem = N'TSQL',
    @command = N'EXEC [GD1C2018].[dbo].[RESERVA_Cancelar_Todas]', 
    @retry_attempts = 0,
    @retry_interval = 0 ;
GO
EXEC dbo.sp_add_schedule
    @schedule_name = N'RunOnce',
    @freq_type = 4,
    @active_start_time = 010000 ;
USE msdb ;
GO
EXEC sp_attach_schedule
   @job_name = N'Cancelar reservas pasada una fecha',
   @schedule_name = N'RunOnce';
GO
EXEC dbo.sp_add_jobserver
    @job_name = N'Cancelar reservas pasada una fecha';
GO