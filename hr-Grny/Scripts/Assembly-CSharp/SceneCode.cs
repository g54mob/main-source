using UnityEngine;

public class SceneCode : MonoBehaviour
{
	public bool ShowProfiling;

	protected bool mIsMotorEnabled;

	public virtual void Update()
	{
	}

	public virtual void NextDemo()
	{
	}

	public void ToggleMotors()
	{
	}

	public virtual void EnableMotors()
	{
	}

	public virtual void DisableMotors()
	{
	}

	protected virtual void EnableMotors(string rName, bool rEnable)
	{
	}

	protected virtual void SetMotorState(string rText)
	{
	}
}
