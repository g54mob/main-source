using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BirdAI : MonoBehaviour, ICritter
{
	public Animator anim;

	public Renderer rend;

	public Renderer[] rends;

	private Vector3 Target;

	private float CountDown = 5f;

	private int _restMode;

	public float Speed = 5f;

	public float TurnRate;

	public float SitYOffset = 0.5f;

	public GameObject Legs;

	private int _minRestFloor = -1;

	private Vector3 _initialScale;

	private float zRot;

	public bool HomeMode;

	[SerializeField]
	private CritterController.Variant[] _variants;

	public int CurrentVariant { get; set; }

	public int TextureCount
	{
		get
		{
			return 0;
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
		return "Bird";
	}

	public float OptimalMaxWeather()
	{
		return 1000f;
	}

	public float OptimalMinWeather()
	{
		return 5f;
	}

	public GameObject GetGameObject()
	{
		return base.gameObject;
	}

	public bool ResetPlace()
	{
		float x = UnityEngine.Random.value * 256f;
		float z = UnityEngine.Random.value * 256f;
		if (UnityEngine.Random.value > 0.5f)
		{
			if (UnityEngine.Random.value > 0.5f)
			{
				x = 0f;
				base.transform.rotation = Quaternion.LookRotation(new Vector3(1f, 0f, 0f));
			}
			else
			{
				x = 256f;
				base.transform.rotation = Quaternion.LookRotation(new Vector3(-1f, 0f, 0f));
			}
		}
		else if (UnityEngine.Random.value > 0.5f)
		{
			z = 0f;
			base.transform.rotation = Quaternion.LookRotation(new Vector3(0f, 0f, 1f));
		}
		else
		{
			z = 256f;
			base.transform.rotation = Quaternion.LookRotation(new Vector3(0f, 0f, -1f));
		}
		base.transform.position = new Vector3(x, UnityEngine.Random.Range(10, 20), z);
		return true;
	}

	public void ApplyTexture(int id)
	{
		throw new NotImplementedException();
	}

	public void Spawn()
	{
		CountDown = 5f;
		_restMode = 0;
		anim.SetTrigger("Fly");
		Legs.SetActive(false);
		HomeMode = false;
		NewTarget();
	}

	private void NewTarget(bool hasRested = false)
	{
		if (!hasRested && UnityEngine.Random.value < 0.1f)
		{
			int num = UnityEngine.Random.Range(0, 5);
			if (num == 0 && GameSettings.Instance.sRoomManager.Roofs.Count > 0)
			{
				Roof roof = null;
				List<Roof> roofs = GameSettings.Instance.sRoomManager.Roofs;
				int num2 = UnityEngine.Random.Range(0, roofs.Count);
				for (int i = 0; i < roofs.Count; i++)
				{
					Roof roof2 = roofs[(i + num2) % roofs.Count];
					if (roof2.Floor <= GameSettings.Instance.ActiveFloor)
					{
						roof = roof2;
						break;
					}
				}
				if (roof != null)
				{
					Roof.RoofEdge random = roof.RoofLine.GetRandom();
					Vector2 v = Vector2.Lerp(random.A.V, random.B.V, UnityEngine.Random.value);
					float y = (float)(roof.Floor * 2) + roof.Height + SitYOffset;
					Target = v.ToVector3(y);
					_restMode = 1;
					_minRestFloor = roof.Floor;
					return;
				}
			}
			if (num == 1)
			{
				List<BurbHouse> list = RoadManager.Instance.Landmarks.OfType<BurbHouse>().ToList();
				if (list.Count > 0)
				{
					BurbHouse random2 = list.GetRandom();
					int num3 = UnityEngine.Random.Range(0, random2.RoofLines.Length / 2);
					Matrix4x4 localToWorldMatrix = random2.transform.localToWorldMatrix;
					Vector3 a = localToWorldMatrix.MultiplyPoint(random2.RoofLines[num3 * 2]);
					Vector3 b = localToWorldMatrix.MultiplyPoint(random2.RoofLines[num3 * 2 + 1]);
					Vector3 vector = Vector3.Lerp(a, b, UnityEngine.Random.value);
					Target = vector + Vector3.up * SitYOffset;
					_restMode = 1;
					_minRestFloor = -1;
					return;
				}
			}
			if (num == 2)
			{
				List<SkraperGen> list2 = RoadManager.Instance.Landmarks.OfType<SkraperGen>().ToList();
				if (list2.Count > 0)
				{
					ValueTuple<Rect, float> random3 = list2.GetRandom().Blobs.GetRandom();
					Rect item = random3.Item1;
					float item2 = random3.Item2;
					Vector2 v2 = ((!(UnityEngine.Random.value > 0.5f)) ? new Vector2(item.min.x + UnityEngine.Random.value * item.width, (UnityEngine.Random.value > 0.5f) ? (item.min.y + 0.1f) : (item.min.y - 0.1f)) : new Vector2((UnityEngine.Random.value > 0.5f) ? (item.min.x + 0.1f) : (item.max.x - 0.1f), item.min.y + UnityEngine.Random.value * item.height));
					Target = v2.ToVector3(item2 + SitYOffset);
					_restMode = 1;
					_minRestFloor = -1;
					return;
				}
			}
			if (num == 3 && RoadManager.Instance.Lamps.Count > 0)
			{
				Vector3 vector2 = RoadManager.Instance.Lamps.GetRandom().transform.localToWorldMatrix.MultiplyPoint(new Vector3(UnityEngine.Random.Range(2.48f, 2.55f), 3.814f, 0f));
				Target = vector2 + Vector3.up * SitYOffset;
				_restMode = 1;
				_minRestFloor = -1;
				return;
			}
			if (num == 4 && GameSettings.Instance.Trees.Count > 0)
			{
				TreeInstance random4 = GameSettings.Instance.Trees.GetRandom();
				Target = random4.Transform.MultiplyPoint(random4.TreeMesh.BirdPoints.GetRandom()) + Vector3.up * SitYOffset;
				_restMode = 1;
				_minRestFloor = -1;
				return;
			}
		}
		Quaternion quaternion = Quaternion.Euler(UnityEngine.Random.Range(-40f, 40f), UnityEngine.Random.Range(-40f, 40f), 0f) * base.transform.rotation;
		float num4 = Mathf.Repeat(quaternion.eulerAngles.x, 360f);
		quaternion = Quaternion.Euler((num4 < 30f) ? Mathf.Clamp(num4, 0f, 30f) : Mathf.Clamp(num4, 330f, 360f), quaternion.eulerAngles.y, quaternion.eulerAngles.z);
		Target = base.transform.position + quaternion * Vector3.forward * 10f;
		Target = new Vector3(Target.x, Mathf.Clamp(Target.y, 10f, 40f), Target.z);
	}

	public void UpdateMe()
	{
		if (GameSettings.GameSpeed == 0f)
		{
			anim.speed = 0f;
			return;
		}
		anim.speed = 1f;
		if (_restMode == 2)
		{
			CountDown -= Time.deltaTime * GameSettings.GameSpeed;
			if (GameSettings.Instance.ActiveFloor >= _minRestFloor && !(CountDown < 0f))
			{
				return;
			}
			anim.SetTrigger("Fly");
			CountDown = UnityEngine.Random.Range(2f, 5f);
			NewTarget(true);
			Legs.SetActive(false);
			_restMode = 0;
		}
		if (!HomeMode && CritterController.ShouldGoHome(this))
		{
			Target = base.transform.forward * 512f;
			Target = new Vector3(Target.x, Mathf.Clamp(Target.y, 10f, 40f), Target.z);
			HomeMode = true;
			_restMode = 0;
		}
		if (!HomeMode)
		{
			if (_restMode == 1)
			{
				if ((Target - base.transform.position).sqrMagnitude < 0.1f * GameSettings.GameSpeed)
				{
					CountDown = UnityEngine.Random.Range(5f, 30f);
					base.transform.position = Target;
					Vector3 eulerAngles = base.transform.rotation.eulerAngles;
					base.transform.rotation = Quaternion.Euler(0f, eulerAngles.y, 0f);
					anim.SetTrigger("Idle");
					Legs.SetActive(true);
					_restMode = 2;
					return;
				}
			}
			else
			{
				CountDown -= Time.deltaTime * GameSettings.GameSpeed;
				if (CountDown < 0f)
				{
					CountDown = UnityEngine.Random.Range(2f, 5f);
					NewTarget();
				}
				else if ((base.transform.position - Target).sqrMagnitude < 1f)
				{
					CountDown = UnityEngine.Random.Range(2f, 5f);
					NewTarget();
				}
			}
		}
		Quaternion quaternion = Quaternion.RotateTowards(base.transform.rotation, Quaternion.LookRotation(Target - base.transform.position), TurnRate * Time.deltaTime * GameSettings.GameSpeed);
		zRot = Mathf.Lerp(zRot, Room.LeftVal(Target.FlattenVector3(), base.transform.position.FlattenVector3(), (base.transform.position - base.transform.forward).FlattenVector3()) * 57.29578f / 2f, Time.deltaTime * GameSettings.GameSpeed);
		Vector3 eulerAngles2 = quaternion.eulerAngles;
		quaternion = Quaternion.Euler(eulerAngles2.x, eulerAngles2.y, zRot);
		float y = (quaternion * Vector3.forward).normalized.y;
		float num = Speed;
		if (y > 0f)
		{
			float num2 = y;
			anim.SetFloat("Flap", 1f - num2);
			num *= 0.25f + (1f - num2) * 0.75f;
		}
		else
		{
			anim.SetFloat("Flap", 0f);
		}
		base.transform.SetPositionAndRotation(base.transform.position + base.transform.forward.normalized * num * Time.deltaTime * GameSettings.GameSpeed, quaternion);
	}

	public int GetCount(GameData.EnvironmentType env, GameData.ClimateType cli)
	{
		if (cli == GameData.ClimateType.Cold)
		{
			return 0;
		}
		return 20;
	}

	public void InitGroup(List<ICritter> group)
	{
	}

	public void SetVisible(bool visible)
	{
		for (int i = 0; i < rends.Length; i++)
		{
			rends[i].enabled = visible;
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawLine(base.transform.position, Target);
	}

	public float OptimalMinLight()
	{
		return 0.9f;
	}

	public float OptimalMaxLight()
	{
		return 2f;
	}

	public void SetOptionalMesh(bool en)
	{
	}

	public List<ICritter> GetGroup()
	{
		return null;
	}

	public bool ShouldUpdate()
	{
		return true;
	}

	public bool ShouldDestroy(bool immediate)
	{
		if (!rend.isVisible)
		{
			if (!(base.transform.position.x < -5f) && !(base.transform.position.x > 261f) && !(base.transform.position.z < -5f))
			{
				return base.transform.position.z > 261f;
			}
			return true;
		}
		return false;
	}
}
