using System;

public interface iMainBossController : iBossController
{
	event Action ControllerDied;
}
