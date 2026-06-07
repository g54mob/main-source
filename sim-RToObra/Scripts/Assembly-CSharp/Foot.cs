using System;
using UnityEngine;

public class Foot
{
	public readonly float radiusMax = 0.5f;

	public readonly float radiusMin = 0.3f;

	private Quaternion rot;

	private float radiusVel;

	private float plantedPerc = 0.8f;

	private int numRestFrames;

	private float totalDeltaAngleSinceRest;

	private bool curFootDown;

	private bool preFootDown;

	private bool slaveInLockStep;

	private float angularVelocity;

	private Quaternion preRot;

	private Average angularVelocityAverage = new Average(15);

	private float restAngle;

	private Quaternion rotRest;

	private Quaternion rotStep;

	public float radius { get; private set; }

	public float plantedAngle0
	{
		get
		{
			return rot.eulerAngles.z * ((float)Math.PI / 180f) - plantedPerc * (float)Math.PI;
		}
	}

	public float plantedAngle1
	{
		get
		{
			return rot.eulerAngles.z * ((float)Math.PI / 180f) + plantedPerc * (float)Math.PI;
		}
	}

	public bool resting
	{
		get
		{
			return numRestFrames >= 2;
		}
	}

	private float circumference
	{
		get
		{
			return (float)Math.PI * 2f * radius;
		}
	}

	public bool footJustDown
	{
		get
		{
			return curFootDown && !preFootDown;
		}
	}

	public bool footJustUp
	{
		get
		{
			return !curFootDown && preFootDown;
		}
	}

	public bool footDown
	{
		get
		{
			return curFootDown;
		}
	}

	public float rotInRadians
	{
		get
		{
			return rot.eulerAngles.z * ((float)Math.PI / 180f);
		}
		set
		{
			rot = Quaternion.AngleAxis(value * 57.29578f, Vector3.forward);
		}
	}

	public float soundVolume
	{
		get
		{
			float num = 3f;
			float inputMax = num / radiusMin;
			return Util.LerpScale(angularVelocityAverage.average, 0f, inputMax, 0.1f, 1f);
		}
	}

	public Vector2 lean
	{
		get
		{
			float f = rotInRadians;
			return new Vector2(Mathf.Cos(f), Mathf.Sin(f));
		}
	}

	public float leanRestY { get; private set; }

	public Foot(bool left_)
	{
		radius = 0.5f;
		float num = -0.75f;
		restAngle = num * 0.5f * (float)Math.PI;
		float num2 = 0.1f;
		rotRest = Quaternion.AngleAxis(57.29578f * restAngle, Vector3.forward);
		rotStep = Quaternion.AngleAxis(57.29578f * (restAngle + (2f - num2) * 0.5f * (float)Math.PI), Vector3.forward);
		leanRestY = radiusMin * Mathf.Sin(restAngle);
		rot = rotRest;
	}

	private void Update(float distanceTraveled, Foot lockStepMaster = null)
	{
		preRot = rot;
		if (lockStepMaster == null)
		{
			float num = rotInRadians;
			float num2 = distanceTraveled / radius;
			totalDeltaAngleSinceRest += num2;
			float num3 = (num + num2) % ((float)Math.PI * 2f);
			numRestFrames = (((double)num2 < 0.001) ? (numRestFrames + 1) : 0);
			if (resting)
			{
				slaveInLockStep = false;
				totalDeltaAngleSinceRest = 0f;
				float t = 0.08f;
				rot = Quaternion.Slerp(rot, rotRest, t);
				angularVelocity = Mathf.Lerp(angularVelocity, 0f, t);
			}
			else
			{
				rotInRadians = num3;
				angularVelocity = (float)Math.PI / 180f * Quaternion.Angle(preRot, rot) / Clock.play.deltaTime;
			}
		}
		else
		{
			float num4 = ((float)Math.PI * 6f + lockStepMaster.rotInRadians - (float)Math.PI) % ((float)Math.PI * 2f);
			Quaternion b = Quaternion.AngleAxis(57.29578f * num4, Vector3.forward);
			rot = Quaternion.Slerp(rot, b, 0.75f);
			if ((float)Math.PI / 180f * Quaternion.Angle(rot, b) < 0.1f)
			{
				rot = b;
				slaveInLockStep = true;
			}
			angularVelocity = Mathf.Lerp(angularVelocity, 0f, 0.1f);
			numRestFrames++;
		}
		angularVelocityAverage.Add(angularVelocity);
		preFootDown = curFootDown;
		curFootDown = Quaternion.Angle(rotStep, rot) * ((float)Math.PI / 180f) < plantedPerc * (float)Math.PI;
	}

	public void UpdateMaster(float distanceTraveled)
	{
		Update(distanceTraveled);
		float target = ((!resting) ? radiusMax : radiusMin);
		radius = Mathf.SmoothDamp(radius, target, ref radiusVel, (!resting) ? 2f : 0.5f);
	}

	public void UpdateSlave(Foot master, float distanceTraveled)
	{
		if (slaveInLockStep)
		{
			Update(distanceTraveled);
		}
		else if (master.resting || master.totalDeltaAngleSinceRest < (float)Math.PI)
		{
			Update(0f);
		}
		else
		{
			Update(0f, master);
		}
		radius = master.radius;
	}
}
