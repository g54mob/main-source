using System;
using System.Collections;
using UnityEngine;

public class Dial360 : MonoBehaviour
{
	public float maxRot = 360f;

	private float angle;

	public Module owner;

	private float val = 0.5f;

	private bool NoAutoSet;

	private Vector3 oPos = Vector3.zero;

	private bool drag;

	public SpriteRenderer shadow;

	private float turnSpeed = 6f;

	private float last;

	private bool sfx;

	public bool fullRot;

	public float GetAngle(float cx, float cy, float ox, float oy, float nx, float ny)
	{
		float num = ox - cx;
		float num2 = oy - cy;
		float num3 = nx - cx;
		float num4 = ny - cy;
		float num5 = Mathf.Sqrt(num * num + num2 * num2);
		float num6 = Mathf.Sqrt(num3 * num3 + num4 * num4);
		return Mathf.Asin(num / num5 * (num4 / num6) - num2 / num5 * (num3 / num6));
	}

	public void Awake()
	{
		if (!NoAutoSet)
		{
			val = 0.5f;
			angle = -90.01f;
			base.transform.localEulerAngles = new Vector3(0f, 0f, angle);
			shadow.transform.position = base.transform.position + new Vector3(0f, -0.0625f);
			Set();
		}
	}

	public float GetAngle()
	{
		return angle;
	}

	public void Preset(float a)
	{
		NoAutoSet = true;
		angle = a;
		float z = Mathf.CeilToInt(angle / 10f) * 10;
		base.transform.localEulerAngles = new Vector3(0f, 0f, z);
		shadow.transform.position = base.transform.position + new Vector3(0f, -0.0625f);
		Set();
	}

	public void Set()
	{
		float num = 0f;
		if (base.transform.localEulerAngles.z < 0f)
		{
			num += 180f + Mathf.Abs(base.transform.localEulerAngles.z) * 2f;
		}
		val = (num + base.transform.localEulerAngles.z) / 360f;
		if (val == 1f)
		{
			val = 0f;
		}
		owner.SetDial(val);
	}

	public static Vector3 GetMousePos()
	{
		return Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(0f, 0f, Camera.main.ScreenToWorldPoint(Input.mousePosition).z);
	}

	private void OnMouseDrag()
	{
		if (!drag)
		{
			oPos = GetMousePos();
			drag = true;
		}
		Vector2 vector = GetMousePos();
		float num = GetAngle(base.transform.position.x, base.transform.position.y, oPos.x, oPos.y, vector.x, vector.y);
		if ((double)Mathf.Abs(num) < 1E-05)
		{
			num = 0f;
		}
		num *= 180f / MathF.PI;
		num *= 1f;
		if (num > 0f)
		{
			Turn(turnSpeed);
		}
		else if (num < 0f)
		{
			Turn(0f - turnSpeed);
		}
		oPos = GetMousePos();
	}

	private IEnumerator PlaySound()
	{
		if (!sfx)
		{
			sfx = true;
			owner.dungeon.audioManager.PlaySound(AudioManager.Sound.Dial);
			yield return Dungeon.WaitUI(3);
			sfx = false;
		}
	}

	private void Turn(float x)
	{
		angle += x;
		angle = Mathf.Clamp(angle, -2f * maxRot, fullRot ? (2f * maxRot) : 0f);
		if (angle >= 360f)
		{
			angle -= 360f;
		}
		else if (angle <= -360f)
		{
			angle += 360f;
		}
		float num = Mathf.CeilToInt(angle / 10f) * 10;
		if (num != last)
		{
			StartCoroutine(PlaySound());
			last = num;
		}
		base.transform.localEulerAngles = new Vector3(0f, 0f, num);
		shadow.transform.position = base.transform.position + new Vector3(0f, -0.0625f);
		Set();
	}

	private void OnMouseEnter()
	{
		owner.dungeon.hoveredModule = owner;
		owner.dungeon.tooltip.Set(owner);
	}

	private void OnMouseExit()
	{
		owner.dungeon.hoveredModule = null;
		owner.dungeon.tooltip.Hide();
	}

	private void PlaySFX()
	{
		StartCoroutine(PlaySound());
	}

	private void OnMouseOver()
	{
		if (Input.mouseScrollDelta.y > 0f)
		{
			PlaySFX();
			Turn((0f - turnSpeed) / 2f);
		}
		if (Input.mouseScrollDelta.y < 0f)
		{
			PlaySFX();
			Turn(turnSpeed / 2f);
		}
		if (Input.GetKeyDown(KeyCode.Mouse1))
		{
			val = 0.5f;
			angle = -90.01f;
			base.transform.localEulerAngles = new Vector3(0f, 0f, angle);
			shadow.transform.position = base.transform.position + new Vector3(0f, -0.0625f);
			Set();
			PlaySFX();
		}
	}
}
