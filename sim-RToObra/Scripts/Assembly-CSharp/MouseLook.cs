using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour
{
	private class Smoother
	{
		private int count;

		private int nextAddIndex;

		private List<float> vals;

		public float average
		{
			get
			{
				float num = 0f;
				for (int i = 0; i < count; i++)
				{
					num += vals[i];
				}
				return num / (float)count;
			}
		}

		public Smoother(int count_)
		{
			nextAddIndex = 0;
			count = count_;
			vals = new List<float>();
			for (int i = 0; i < count; i++)
			{
				vals.Add(0f);
			}
		}

		public void Add(float val)
		{
			vals[nextAddIndex] = val;
			nextAddIndex++;
			if (nextAddIndex > count)
			{
				count = nextAddIndex;
			}
			if (nextAddIndex >= vals.Count)
			{
				nextAddIndex = 0;
			}
		}

		public void Zero()
		{
			count = 0;
		}
	}

	public enum RotationAxes
	{
		MouseXAndY = 0,
		MouseX = 1,
		MouseY = 2
	}

	public RotationAxes axes;

	public float sensitivityX = 15f;

	public float sensitivityY = 15f;

	public float minimumY = -60f;

	public float maximumY = 60f;

	public float rotationY;

	private int waitFrames = 10;

	private Smoother smootherX = new Smoother(2);

	private Smoother smootherY = new Smoother(2);

	private void Start()
	{
		if ((bool)GetComponent<Rigidbody>())
		{
			GetComponent<Rigidbody>().freezeRotation = true;
		}
		base.transform.localEulerAngles = new Vector3(0f - rotationY, base.transform.localEulerAngles.y, 0f);
	}

	private void Update()
	{
		if (!Clock.play.running)
		{
			smootherX.Zero();
			smootherY.Zero();
			return;
		}
		if (waitFrames > 0)
		{
			waitFrames--;
			smootherX.Zero();
			smootherY.Zero();
			return;
		}
		float num = RInput.GetAxis(2);
		float num2 = RInput.GetAxis(3);
		if (Mathf.Abs(num) > 100f || Mathf.Abs(num2) > 100f)
		{
			num = 0f;
			num2 = 0f;
		}
		if (RInput.mouseIsActive)
		{
			num *= 0.275f;
			num2 *= 0.275f;
			smootherX.Add(num);
			num = smootherX.average;
			smootherY.Add(num2);
			num2 = smootherY.average;
		}
		else
		{
			num = num * Clock.play.deltaTime * 30f;
			num2 = num2 * Clock.play.deltaTime * 30f * 0.8f;
		}
		float num3 = Mathf.Lerp(0.25f, 1f, Player.cameraFovT);
		num = num * sensitivityX * num3 * Settings.lookSpeedX;
		num2 = num2 * sensitivityY * num3 * Settings.lookSpeedY;
		if (Settings.lookInvertY)
		{
			num2 = 0f - num2;
		}
		if (axes == RotationAxes.MouseXAndY)
		{
			float y = base.transform.localEulerAngles.y + num;
			rotationY += num2;
			rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
			base.transform.localEulerAngles = new Vector3(0f - rotationY, y, 0f);
		}
		else if (axes == RotationAxes.MouseX)
		{
			base.transform.Rotate(0f, num, 0f);
		}
		else
		{
			rotationY += num2;
			rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
			base.transform.localEulerAngles = new Vector3(0f - rotationY, base.transform.localEulerAngles.y, 0f);
		}
	}

	public void DisableInputForOneFrame()
	{
		if (waitFrames == 0)
		{
			waitFrames = 1;
		}
	}

	public void Look(Quaternion q)
	{
		if (axes == RotationAxes.MouseXAndY)
		{
			rotationY = 0f - q.eulerAngles.x;
			base.transform.localRotation = Quaternion.Euler(0f - rotationY, q.eulerAngles.y, 0f);
			return;
		}
		if (axes == RotationAxes.MouseX)
		{
			base.transform.localRotation = Quaternion.Euler(0f, q.eulerAngles.y, 0f);
			return;
		}
		for (rotationY = 0f - q.eulerAngles.x; rotationY < -180f; rotationY += 360f)
		{
		}
		while (rotationY > 180f)
		{
			rotationY -= 360f;
		}
		base.transform.localRotation = Quaternion.Euler(0f - rotationY, base.transform.localEulerAngles.y, 0f);
	}

	public Quaternion ClampForLook(Quaternion q)
	{
		if (axes == RotationAxes.MouseY)
		{
			Vector3 eulerAngles = q.eulerAngles;
			while (eulerAngles.x < -180f)
			{
				eulerAngles.x += 360f;
			}
			while (eulerAngles.x > 180f)
			{
				eulerAngles.x -= 360f;
			}
			eulerAngles.x = Mathf.Clamp(eulerAngles.x, minimumY, maximumY);
			return Quaternion.Euler(eulerAngles);
		}
		return q;
	}
}
