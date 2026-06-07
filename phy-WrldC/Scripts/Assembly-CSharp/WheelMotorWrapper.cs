using NWH.WheelController3D;
using UnityEngine;

public class WheelMotorWrapper
{
	private WheelColliderSource wheelColliderSource;

	private WheelController wheelController;

	public GameObject GameObject { get; set; }

	public float MotorTorque
	{
		get
		{
			if (wheelColliderSource != null)
			{
				return wheelColliderSource.MotorTorque;
			}
			if (wheelController != null)
			{
				return wheelController.motorTorque;
			}
			return 0f;
		}
		set
		{
			if (wheelColliderSource != null)
			{
				wheelColliderSource.MotorTorque = value;
			}
			else if (wheelController != null)
			{
				wheelController.motorTorque = value;
			}
		}
	}

	public float BrakeTorque
	{
		get
		{
			if (wheelColliderSource != null)
			{
				return wheelColliderSource.BrakeTorque;
			}
			if (wheelController != null)
			{
				return wheelController.brakeTorque;
			}
			return 0f;
		}
		set
		{
			if (wheelColliderSource != null)
			{
				wheelColliderSource.BrakeTorque = value;
			}
			else if (wheelController != null)
			{
				wheelController.brakeTorque = value;
			}
		}
	}

	public float RPM
	{
		get
		{
			if (wheelColliderSource != null)
			{
				return wheelColliderSource.RPM;
			}
			if (wheelController != null)
			{
				return wheelController.rpm;
			}
			return 0f;
		}
	}

	public bool IsGrounded
	{
		get
		{
			if (wheelColliderSource != null)
			{
				return wheelColliderSource.IsGrounded;
			}
			if (wheelController != null)
			{
				return wheelController.isGrounded;
			}
			return false;
		}
	}

	public void SetWheelMotor(object wheelMotor)
	{
		wheelColliderSource = null;
		wheelController = null;
		if (wheelMotor is WheelColliderSource)
		{
			wheelColliderSource = wheelMotor as WheelColliderSource;
		}
		else if (wheelMotor is WheelController)
		{
			wheelController = wheelMotor as WheelController;
		}
	}

	public void SetActive(bool shoudEnable)
	{
		if (wheelColliderSource != null)
		{
			wheelColliderSource.enabled = shoudEnable;
		}
		else if (wheelController != null)
		{
			wheelController.enabled = shoudEnable;
		}
	}
}
