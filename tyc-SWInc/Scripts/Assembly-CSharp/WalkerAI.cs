using System;
using System.Collections.Generic;
using UnityEngine;

public class WalkerAI : MonoBehaviour, ICritter
{
	public bool CanSprint = true;

	public bool Herding;

	private bool Walk;

	private bool Run;

	private bool Sleeping;

	[NonSerialized]
	private SDateTime LastSleep;

	public int IdleAnimations;

	public float Timer = 10f;

	public float Speed = 5f;

	public float RunSpeed = 2f;

	public float TurnSpeed = 1f;

	public float LookAhead = 1f;

	public float RunTimer;

	public float Warm;

	public float Temperate;

	public float Cold;

	public float City;

	public float Town;

	public float Rural;

	public Vector2 Sleep = Vector2.zero;

	public float SleepHours;

	public Animator Anim;

	public Renderer Rend;

	public Renderer[] Rends;

	public string CritterType;

	public GameObject OptionalMesh;

	public Texture[] TextureVariants;

	public Texture EyesOpen;

	public Texture EyesClosed;

	private bool _walkRight;

	private bool _walkRightSet;

	private float _turnTimer;

	private float _turnDeg;

	private float _aliveTimer;

	private List<ICritter> Group;

	private Vector2 _targetOffset;

	[NonSerialized]
	private Vector3 _initialScale;

	[NonSerialized]
	private float _blinkTimer;

	[NonSerialized]
	private bool _blinking;

	[SerializeField]
	private CritterController.Variant[] _variants;

	public int CurrentVariant { get; set; }

	public int TextureCount
	{
		get
		{
			return TextureVariants.Length;
		}
	}

	public Vector3 InitialScale
	{
		get
		{
			return _initialScale;
		}
	}

	public CritterController.Variant[] Variants
	{
		get
		{
			return _variants;
		}
	}

	private void Awake()
	{
		_initialScale = base.transform.localScale;
	}

	public string GetTypeName()
	{
		return CritterType;
	}

	public bool ResetPlace()
	{
		_targetOffset = GetPointOnCircle(0.5f, 2f);
		Vector3? vector = null;
		if (Herding)
		{
			for (int i = 0; i < Group.Count; i++)
			{
				ICritter critter = Group[i];
				if (critter != this && critter.GetGameObject().activeSelf)
				{
					vector = critter.GetGameObject().transform.position + _targetOffset.ToVector3(0f);
					break;
				}
			}
		}
		if (!vector.HasValue)
		{
			Vector2? vector2 = GameSettings.Instance.sRoomManager.Outside.FindRandomSpot();
			if (vector2.HasValue)
			{
				vector = vector2.Value.ToVector3(0f);
			}
		}
		if (vector.HasValue)
		{
			Vector3 vector3 = CameraScript.Instance.mainCam.WorldToViewportPoint(vector.Value);
			if (vector3.x >= 0f && vector3.x <= 1f && vector3.y >= 0f && vector3.y <= 1f && vector3.z >= 0f)
			{
				return false;
			}
			base.transform.position = vector.Value;
			base.transform.rotation = Quaternion.Euler(0f, UnityEngine.Random.Range(0, 360), 0f);
			return true;
		}
		return false;
	}

	public float OptimalMinWeather()
	{
		return -1000f;
	}

	public float OptimalMaxWeather()
	{
		return 1000f;
	}

	public float OptimalMinLight()
	{
		return -1f;
	}

	public float OptimalMaxLight()
	{
		return 2f;
	}

	public void SetOptionalMesh(bool en)
	{
		if (OptionalMesh != null)
		{
			OptionalMesh.SetActive(en);
		}
	}

	public List<ICritter> GetGroup()
	{
		return Group;
	}

	public void ApplyTexture(int id)
	{
		Rend.material.SetTexture("_MainTex", TextureVariants[id]);
	}

	public void Spawn()
	{
		SetIdle(UnityEngine.Random.value > 0.5f);
		_turnTimer = UnityEngine.Random.Range(30f, 60f);
		_turnDeg = UnityEngine.Random.Range(20f, 90f);
		LastSleep = SDateTime.Now();
		if (EyesClosed != null)
		{
			Rend.material.SetTexture("_EmissionMap", EyesOpen);
		}
	}

	private void SetIdle(bool idle)
	{
		if (idle)
		{
			Timer = UnityEngine.Random.Range(5f, 10f);
			if (!Run)
			{
				Anim.SetTrigger("Idle");
				Anim.SetInteger("IdleIdx", UnityEngine.Random.Range(0, IdleAnimations));
				Walk = false;
			}
		}
		else
		{
			UpdateRunStatus(true);
			Walk = true;
			Timer = UnityEngine.Random.Range(5f, 30f);
		}
	}

	private void UpdateRunStatus(bool force)
	{
		if (CanSprint)
		{
			bool flag = RoadManager.Instance.GetRoad(base.transform.position.FlattenVector3(), 0) != 0;
			if (force || flag != Run)
			{
				Run = flag;
				if (!Run)
				{
					RunTimer = 0f;
				}
				Anim.SetTrigger(Run ? "Sprint" : "Walk");
			}
		}
		else if (force)
		{
			Anim.SetTrigger("Walk");
		}
	}

	private bool CheckCollision(Vector2 p, float border, bool nav = true)
	{
		if (p.x < border || p.x > 256f - border || p.y < border || p.y > 256f - border)
		{
			return true;
		}
		if (!GameSettings.Instance.sRoomManager.Outside.GetNavMeshRunning() && nav)
		{
			return GameSettings.Instance.sRoomManager.Outside.GetNodeAt(p, false) == null;
		}
		return false;
	}

	public GameObject GetGameObject()
	{
		return base.gameObject;
	}

	public bool ShouldUpdate()
	{
		if (Rend.isVisible)
		{
			_aliveTimer = 10f;
			return true;
		}
		if (_aliveTimer > 0f)
		{
			_aliveTimer -= Time.deltaTime;
			return true;
		}
		return false;
	}

	public bool ShouldDestroy(bool immediate)
	{
		if (immediate)
		{
			if (CheckCollision(base.transform.position.FlattenVector3(), 1f))
			{
				return true;
			}
		}
		else if (RunTimer > 30f || CheckCollision(base.transform.position.FlattenVector3(), 1f))
		{
			return true;
		}
		return false;
	}

	private Vector3? GetTargetPosition(out bool herded)
	{
		herded = false;
		if (CheckCollision(base.transform.position.FlattenVector3(), 8f, false))
		{
			return new Vector3(128f, 0f, 128f);
		}
		if (Herding)
		{
			for (int i = 0; i < Group.Count; i++)
			{
				if (Group[i] == this)
				{
					return null;
				}
				if (Group[i].GetGameObject().activeSelf)
				{
					herded = true;
					return Group[i].GetGameObject().transform.position + _targetOffset.ToVector3(0f);
				}
			}
		}
		return null;
	}

	public bool ShouldSleep()
	{
		if (Sleep.x > 0f)
		{
			float num = (float)TimeOfDay.Instance.Hour + TimeOfDay.Instance.Minute / 60f;
			if (Sleep.x > Sleep.y)
			{
				if (!(num < Sleep.y))
				{
					return num > Sleep.x;
				}
				return true;
			}
			if (num > Sleep.x)
			{
				return num < Sleep.y;
			}
			return false;
		}
		if (SleepHours > 0f)
		{
			if (Sleeping && Timer > 0f)
			{
				Timer -= Time.deltaTime * GameSettings.GameSpeed;
				if (Timer <= 0f)
				{
					LastSleep = SDateTime.Now();
					return false;
				}
				return true;
			}
			if (SDateTime.GetHours(LastSleep, SDateTime.Now()) > SleepHours * 4f)
			{
				Timer = SleepHours * 60f;
				return true;
			}
		}
		return false;
	}

	public void UpdateMe()
	{
		Anim.speed = GameSettings.GameSpeed;
		if (GameSettings.GameSpeed == 0f)
		{
			return;
		}
		if (!Run && ShouldSleep())
		{
			if (!Sleeping)
			{
				if (EyesClosed != null)
				{
					Rend.material.SetTexture("_EmissionMap", EyesClosed);
				}
				Walk = false;
				Anim.SetTrigger("Sleep");
				Sleeping = true;
			}
			return;
		}
		float num = Time.deltaTime * GameSettings.GameSpeed;
		if (Sleeping)
		{
			if (EyesClosed != null)
			{
				Rend.material.SetTexture("_EmissionMap", EyesOpen);
				_blinking = false;
			}
			Sleeping = false;
			SetIdle(true);
		}
		if (EyesClosed != null)
		{
			_blinkTimer -= Time.deltaTime * GameSettings.GameSpeed;
			if (_blinkTimer < 0f)
			{
				if (_blinking)
				{
					Rend.material.SetTexture("_EmissionMap", EyesOpen);
					_blinkTimer = UnityEngine.Random.Range(1f, 6f);
				}
				else
				{
					Rend.material.SetTexture("_EmissionMap", EyesClosed);
					_blinkTimer = 0.2f;
				}
				_blinking = !_blinking;
			}
		}
		if (Timer >= 0f)
		{
			Timer -= num;
			if (Timer < 0f)
			{
				SetIdle(Walk);
			}
		}
		if (!Walk)
		{
			return;
		}
		UpdateRunStatus(false);
		if (Run)
		{
			RunTimer += num;
		}
		float num2 = (Run ? RunSpeed : 1f);
		base.transform.position = base.transform.position + base.transform.forward * Speed * num * num2;
		bool flag = false;
		if (!CheckCollision(base.transform.position.FlattenVector3(), 8f, false))
		{
			Vector2 vector = (base.transform.position + base.transform.forward * LookAhead).FlattenVector3();
			Vector2 vector2 = base.transform.right.FlattenVector3() * LookAhead * 0.5f;
			if (CheckCollision(vector + vector2, 8f))
			{
				base.transform.rotation = base.transform.rotation * Quaternion.Euler(0f, (0f - TurnSpeed) * num * num2, 0f);
				flag = true;
			}
			else if (CheckCollision(vector - vector2, 8f))
			{
				base.transform.rotation = base.transform.rotation * Quaternion.Euler(0f, TurnSpeed * num * num2, 0f);
				flag = true;
			}
		}
		bool herded = false;
		if (!flag)
		{
			Vector3? targetPosition = GetTargetPosition(out herded);
			if (targetPosition.HasValue)
			{
				Vector3 forward = targetPosition.Value - base.transform.position;
				if (forward.sqrMagnitude > 16f)
				{
					base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, Quaternion.LookRotation(forward), TurnSpeed * num * num2);
					flag = true;
				}
			}
		}
		if (!flag && RunTimer > 20f)
		{
			if (RunTimer % 20f < 0.5f)
			{
				if (!_walkRightSet)
				{
					_walkRight = UnityEngine.Random.value > 0.5f;
					_walkRightSet = true;
				}
				base.transform.rotation = base.transform.rotation * Quaternion.Euler(0f, TurnSpeed * num * (_walkRight ? num2 : (0f - num2)), 0f);
				flag = true;
			}
			else
			{
				_walkRightSet = false;
			}
		}
		if (flag || herded)
		{
			return;
		}
		_turnTimer -= num;
		if (_turnTimer < 0f)
		{
			base.transform.rotation = base.transform.rotation * Quaternion.Euler(0f, TurnSpeed * num * (_walkRight ? num2 : (0f - num2)), 0f);
			if (_turnTimer < (0f - _turnDeg) / TurnSpeed)
			{
				_walkRight = UnityEngine.Random.value > 0.5f;
				_turnDeg = UnityEngine.Random.Range(20f, 90f);
				_turnTimer = UnityEngine.Random.Range(30f, 60f);
			}
		}
	}

	public int GetCount(GameData.EnvironmentType env, GameData.ClimateType cli)
	{
		float num = 0f;
		switch (env)
		{
		case GameData.EnvironmentType.Rural:
			num = Rural;
			break;
		case GameData.EnvironmentType.Town:
			num = Town;
			break;
		case GameData.EnvironmentType.City:
			num = City;
			break;
		}
		float num2 = 0f;
		switch (cli)
		{
		case GameData.ClimateType.Cold:
			num2 = Cold;
			break;
		case GameData.ClimateType.Temperate:
			num2 = Temperate;
			break;
		case GameData.ClimateType.Warm:
			num2 = Warm;
			break;
		}
		return Mathf.RoundToInt(num * num2);
	}

	public void InitGroup(List<ICritter> group)
	{
		Group = group;
	}

	public void SetVisible(bool visible)
	{
		for (int i = 0; i < Rends.Length; i++)
		{
			Rends[i].enabled = visible;
		}
	}

	private Vector2 GetPointOnCircle(float minRadius, float maxRadius)
	{
		float f = UnityEngine.Random.Range(0f, (float)Math.PI * 2f);
		float num = UnityEngine.Random.Range(minRadius, maxRadius);
		return new Vector2(Mathf.Cos(f) * num, Mathf.Sin(f) * num);
	}
}
