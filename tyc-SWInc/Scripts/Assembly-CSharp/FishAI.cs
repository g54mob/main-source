using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FishAI : MonoBehaviour, ICritter
{
	public string Type;

	public bool CanRest;

	public bool Wave;

	private float _restTimer;

	private float _waveTimer;

	public float MinDepth;

	public float MaxDepth;

	public float MaxDepthChange;

	public float MinTemp;

	public float MinLight;

	public float Speed;

	public float TurnSpeed;

	public float Warm;

	public float Temperate;

	public float Cold;

	public float City;

	public float Town;

	public float Rural;

	public int AnimationType;

	public Animation Anim1;

	public Animator Anim2;

	public Vector3 Target;

	public Renderer Rend;

	public List<ICritter> Group;

	public Lake ParentLake;

	public Texture[] TextureVariants;

	[NonSerialized]
	private Lake.TriangleNode _lastNode;

	[NonSerialized]
	private Vector3 _initialScale;

	private static Dictionary<Texture, Material> _cachedMats = new Dictionary<Texture, Material>();

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
		return Type;
	}

	public bool ResetPlace()
	{
		if (ParentLake == null)
		{
			List<Lake> list = RoadManager.Instance.Landmarks.OfType<Lake>().ToList();
			if (list.Count > 0)
			{
				if (list.Count == 1)
				{
					ParentLake = list[0];
				}
				else
				{
					ParentLake = list.MaxInstance((Lake x) => x.LakeSize / (float)(Group.Count((ICritter z) => ((FishAI)z).ParentLake == x) + 1));
				}
			}
		}
		if (ParentLake == null)
		{
			return false;
		}
		_lastNode = ParentLake.Nodes.GetRandom();
		Vector2 randomTrianglePoint = _lastNode.Points.GetRandomTrianglePoint();
		base.transform.position = randomTrianglePoint.ToVector3(UnityEngine.Random.Range(MinDepth, MaxDepth));
		base.transform.rotation = Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f), 0f);
		PickNewTarget();
		return true;
	}

	private void PickNewTarget()
	{
		_lastNode = ((_lastNode.Connections.Count > 0) ? _lastNode.Connections.GetRandom() : _lastNode);
		Target = _lastNode.Points.GetRandomTrianglePoint().ToVector3(Mathf.Clamp(base.transform.position.y + UnityEngine.Random.Range(0f - MaxDepthChange, MaxDepthChange), MinDepth, MaxDepth));
	}

	public float OptimalMinWeather()
	{
		return MinTemp;
	}

	public float OptimalMaxWeather()
	{
		return float.MaxValue;
	}

	public float OptimalMinLight()
	{
		return MinLight;
	}

	public float OptimalMaxLight()
	{
		return float.MaxValue;
	}

	public void SetOptionalMesh(bool en)
	{
	}

	public List<ICritter> GetGroup()
	{
		return Group;
	}

	public void ApplyTexture(int id)
	{
		Material value;
		if (_cachedMats.TryGetValue(TextureVariants[id], out value))
		{
			Rend.sharedMaterial = value;
			return;
		}
		Rend.material.SetTexture("_MainTex", TextureVariants[id]);
		_cachedMats[TextureVariants[id]] = Rend.sharedMaterial;
	}

	public void Spawn()
	{
		_restTimer = -1f;
	}

	public GameObject GetGameObject()
	{
		return base.gameObject;
	}

	public bool ShouldUpdate()
	{
		return Rend.isVisible;
	}

	public bool ShouldDestroy(bool immediate)
	{
		if (!immediate)
		{
			if (!(TimeOfDay.Instance.SnowAmount > 0.1f))
			{
				return CritterController.ShouldGoHome(this);
			}
			return true;
		}
		return false;
	}

	public void UpdateMe()
	{
		if (AnimationType == 1)
		{
			foreach (AnimationState item in Anim1)
			{
				item.speed = GameSettings.GameSpeed;
			}
		}
		else if (AnimationType == 2)
		{
			Anim2.speed = GameSettings.GameSpeed;
		}
		if (_restTimer > 0f)
		{
			_restTimer -= Time.deltaTime * GameSettings.GameSpeed;
			UpdateWave();
			return;
		}
		float sqrMagnitude = (base.transform.position - Target).sqrMagnitude;
		if (sqrMagnitude < 6f)
		{
			PickNewTarget();
			if (CanRest && UnityEngine.Random.value > 0.5f)
			{
				_restTimer = UnityEngine.Random.Range(5, 40);
				return;
			}
		}
		float num = Time.deltaTime * GameSettings.GameSpeed;
		Quaternion quaternion = Quaternion.LookRotation(Target - base.transform.position);
		float num2 = (1f - Mathf.Abs(Quaternion.Angle(base.transform.rotation, quaternion) / 180f - 0.5f) * 2f).WeightOne(0.75f);
		base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, quaternion, TurnSpeed * num * num2);
		float num3 = (CanRest ? sqrMagnitude.MapRange(6f, 16f, 0.1f, 1f, true) : 1f);
		base.transform.position = base.transform.position + base.transform.forward * Speed * num3 * num;
		UpdateWave();
	}

	private void UpdateWave()
	{
		if (Wave)
		{
			_waveTimer = (_waveTimer + Time.deltaTime * GameSettings.GameSpeed * 2f) % ((float)Math.PI * 2f);
			base.transform.position = base.transform.position.ReplaceY(MaxDepth + Mathf.Sin(_waveTimer) * 0.03f);
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
		Rend.enabled = visible;
	}
}
