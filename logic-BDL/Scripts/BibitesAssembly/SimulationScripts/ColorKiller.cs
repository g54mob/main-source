using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using ScriptHelpers;
using SimulationScripts.BibiteScripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SimulationScripts
{
	public class ColorKiller : MonoBehaviour, ISaveable
	{
		[SerializeField]
		private LayerMask bibiteMask;

		[SerializeField]
		private SpriteRenderer body;

		[SerializeField]
		private SpriteRenderer crystal;

		private Material crystalMaterial;

		[SerializeField]
		private Image laser;

		private RectTransform laserRect;

		private Collider2D[] targetsInView = new Collider2D[128];

		public float hue;

		public float tolerance;

		public bool bodyOrEye;

		public bool anyOrMost;

		public Zone attachedSpawner;

		public float radius;

		public float period;

		[NonSerialized]
		public int killed;

		[NonSerialized]
		public bool placed;

		private GraphicRaycaster rayCaster;

		private EventSystem eventSystem;

		private Camera cam;

		public float progress;

		private static readonly int Color1 = Shader.PropertyToID("_color");

		private void Awake()
		{
			laserRect = laser.GetComponent<RectTransform>();
			crystalMaterial = crystal.material;
		}

		private void Start()
		{
			laserRect = laser.GetComponent<RectTransform>();
			cam = Camera.main;
			crystalMaterial = crystal.material;
			rayCaster = GameObject.Find("UICanvas").GetComponent<GraphicRaycaster>();
			eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
			if (!placed)
			{
				PlacementMode();
			}
		}

		public void Update()
		{
			if (placed)
			{
				return;
			}
			bool mouseButton = Input.GetMouseButton(0);
			bool mouseButton2 = Input.GetMouseButton(1);
			Vector3 vector = cam.ScreenToWorldPoint(Input.mousePosition);
			base.transform.position = new Vector3(vector.x, vector.y, 0f);
			if (mouseButton2)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
			else if (mouseButton)
			{
				PointerEventData pointerEventData = new PointerEventData(eventSystem);
				pointerEventData.position = Input.mousePosition;
				List<RaycastResult> list = new List<RaycastResult>();
				rayCaster.Raycast(pointerEventData, list);
				if (!list.Any())
				{
					Place();
				}
			}
		}

		public void FixedUpdate()
		{
			if (attachedSpawner != null)
			{
				base.transform.position = attachedSpawner.transform.position;
			}
			progress += Time.fixedDeltaTime;
			if (progress < period)
			{
				return;
			}
			progress -= period;
			Physics2D.OverlapCircleNonAlloc(base.transform.position, radius, targetsInView, bibiteMask);
			float num = 0f;
			GameObject gameObject = null;
			for (int i = 0; i < 128 && !(targetsInView[i] == null); i++)
			{
				BibiteGenes component = targetsInView[i].transform.parent.gameObject.GetComponent<BibiteGenes>();
				if (component == null)
				{
					continue;
				}
				Color bodyColor = component.GetBodyColor();
				if (UnityEngine.Random.value > bodyColor.a)
				{
					continue;
				}
				Color.RGBToHSV(bodyColor, out var H, out var S, out var V);
				H = (bodyOrEye ? (H - component.Gene(BibiteGenes.Genes.EyeOffset)) : H);
				H = ((H < 0f) ? (H + 1f) : H);
				float num2 = Mathf.Min(Mathf.Abs(H - hue), Mathf.Abs(Mathf.Abs(H - hue) - 1f));
				if (!bodyOrEye)
				{
					num2 = 1f - (1f - num2) * S * V;
				}
				if (!(num2 < tolerance))
				{
					if (!anyOrMost)
					{
						KillTargetBibite(component.gameObject.GetComponent<BibiteBody>());
						break;
					}
					if (!(num2 < num))
					{
						num = num2;
						gameObject = component.gameObject;
					}
				}
			}
			if (anyOrMost && gameObject != null)
			{
				KillTargetBibite(gameObject.GetComponent<BibiteBody>());
			}
		}

		public void KillTargetBibite(BibiteBody bibite)
		{
			Vector3 vector = bibite.transform.position - base.transform.position;
			float z = Vector2.SignedAngle(Vector2.right, vector);
			laser.gameObject.SetActive(value: true);
			laserRect.rotation = Quaternion.Euler(0f, 0f, z);
			laserRect.sizeDelta = new Vector2(vector.magnitude, 3f);
			killed++;
			StartCoroutine(TurnOffLaser(0.25f));
			bibite.Die();
		}

		public IEnumerator TurnOffLaser(float delay)
		{
			yield return new WaitForSeconds(delay);
			laser.gameObject.SetActive(value: false);
		}

		private void OnDrawGizmos()
		{
			Gizmos.DrawWireSphere(base.transform.position, radius);
		}

		public void UpdateHue(float h)
		{
			hue = h;
			Color color = Color.HSVToRGB(hue, 1f, 1f);
			crystalMaterial.SetColor(Color1, color);
			laser.color = color;
		}

		public void PlacementMode()
		{
			body.color = new Color(1f, 1f, 1f, 0.5f);
			Color color = Color.HSVToRGB(hue, 1f, 1f);
			crystalMaterial.SetColor(Color1, color);
			laser.color = color;
		}

		public void Place()
		{
			body.color = new Color(1f, 1f, 1f, 1f);
			Color color = Color.HSVToRGB(hue, 1f, 1f);
			crystalMaterial.SetColor(Color1, color);
			laser.color = color;
			placed = true;
		}

		public JObject SaveState()
		{
			JObject jObject = new JObject();
			SerializationHelper.SerializePosition(jObject, base.gameObject);
			jObject["hue"] = hue;
			jObject["tolerance"] = tolerance;
			jObject["bodyOrEye"] = bodyOrEye;
			jObject["anyOrMost"] = anyOrMost;
			jObject["radius"] = radius;
			jObject["period"] = period;
			jObject["progress"] = progress;
			if (attachedSpawner != null)
			{
				jObject["followingZone"] = attachedSpawner.settings.zoneID;
			}
			return jObject;
		}

		public void LoadState(JObject state)
		{
			SerializationHelper.DeserializePosition(state, base.gameObject);
			hue = state["hue"].ToObject<float>();
			Place();
			tolerance = state["tolerance"].ToObject<float>();
			bodyOrEye = state["bodyOrEye"].ToObject<bool>();
			anyOrMost = state["anyOrMost"].ToObject<bool>();
			radius = state["radius"].ToObject<float>();
			period = state["period"].ToObject<float>();
			progress = state["progress"].ToObject<float>();
			if (state["followingZone"] != null)
			{
				int id = state["followingZone"].ToObject<int>();
				attachedSpawner = ZoneManager.instance.zones.FirstOrDefault((Zone s) => s.settings.zoneID == id);
			}
		}
	}
}
