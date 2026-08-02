using System.Collections;
using Polarith.UnityUtils;
using UnityEngine;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/Perception/AIM Lod Group")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-lodgroup.html")]
	[RequireComponent(typeof(AIMContext))]
	public sealed class AIMLodGroup : MonoBehaviour
	{
		[Tooltip("The distance between the position of the 'Center' and the position of this game object is used to determine the correct LOD 'AIMSensor'. If this value is 'null', the 'CenterTag' is used to find a proper 'Transform'.")]
		public Transform Center;

		[Tooltip("Specifies how often this component is updated. By using an 'UpdateFrequency' greater than 0, it is possible to save many distance calculations, since an instant replacement of the 'AIMSensor' is not necessary in most cases. Note that if this value is set to 0, this component updates as often as possible.")]
		[Range(0f, 1000f)]
		public float UpdateFrequency = 20f;

		[Tooltip("If enabled, the agent's 'AIMContext' component is disabled if its distance is greater than the  furthest LOD distance. It is reactivated if the distance becomes smaller than the furthest LOD distance respectively. Otherwise, the agent stays active and uses the specified sensor.")]
		public bool DeactivateOnLast;

		[Tooltip("Every element defines one level of detail, so the concrete sensor which should be used at a certain distance.")]
		public LodList LodList = new LodList();

		[Tooltip("First iterative level-of-detail color.")]
		public Color LodColor1 = Colors.Red;

		[Tooltip("Second iterative level-of-detail color.")]
		public Color LodColor2 = Colors.Orange;

		[Tooltip("Third iterative level-of-detail color.")]
		public Color LodColor3 = Colors.Yellow;

		[Tooltip("The 'CenterTag' is used for initialization, which is done in 'Start'. If the 'Center' is 'null', a lookup for a proper 'Transform' is done using this tag. If it is not possible to find a game object with the given tag, this component is deactivated.")]
		[SerializeField]
		[Tag]
		private string centerTag = "MainCamera";

		[SerializeField]
		[HideInInspector]
		private TabState tabState;

		private AIMContext aimContext;

		private WaitForSeconds waitForSeconds;

		private float oldUpdateFrequency = float.PositiveInfinity;

		private float lodDist;

		private float sqrDist;

		private bool updateRoutineRunning;

		public string CenterTag
		{
			get
			{
				return centerTag;
			}
			set
			{
				centerTag = value;
				if (Center == null)
				{
					GameObject gameObject = GameObject.FindGameObjectWithTag(centerTag);
					if (gameObject != null)
					{
						Center = gameObject.transform;
					}
					else
					{
						base.enabled = false;
					}
				}
			}
		}

		private void OnDrawGizmosSelected()
		{
			if (!(Center == null))
			{
				Camera current = Camera.current;
				Vector3 vector = Vector3.zero;
				if (current != null && current.gameObject == Center.gameObject)
				{
					vector = current.transform.forward * (current.nearClipPlane + 0.02f);
				}
				Color[] array = new Color[3] { LodColor1, LodColor2, LodColor3 };
				for (int i = 0; i < LodList.Count - 1; i++)
				{
					Gizmos.color = array[i % array.Length];
					Gizmos.DrawWireSphere(Center.position + vector, LodList[i].Distance);
				}
			}
		}

		private void Start()
		{
			if (Center == null)
			{
				GameObject gameObject = GameObject.FindGameObjectWithTag(centerTag);
				if (gameObject != null)
				{
					Center = gameObject.transform;
				}
				else
				{
					base.enabled = false;
				}
			}
			aimContext = GetComponent<AIMContext>();
		}

		private void Update()
		{
			if (UpdateFrequency != oldUpdateFrequency && UpdateFrequency >= 1E-06f)
			{
				waitForSeconds = new WaitForSeconds(1f / UpdateFrequency);
			}
			oldUpdateFrequency = UpdateFrequency;
			if (!updateRoutineRunning && UpdateFrequency >= 1E-06f)
			{
				StartCoroutine(UpdateRoutine());
			}
			else if (UpdateFrequency < 1E-06f)
			{
				UpdateLod();
			}
		}

		private IEnumerator UpdateRoutine()
		{
			updateRoutineRunning = true;
			while (base.enabled && base.gameObject.activeInHierarchy && UpdateFrequency >= 1E-06f)
			{
				UpdateLod();
				yield return waitForSeconds;
			}
			updateRoutineRunning = false;
		}

		private void UpdateLod()
		{
			if (LodList.Count <= 1)
			{
				return;
			}
			sqrDist = (base.transform.position - Center.position).sqrMagnitude;
			aimContext.Sensor = ((LodList[LodList.Count - 1].Sensor == null) ? aimContext.Sensor : LodList[LodList.Count - 1].Sensor);
			for (int i = 0; i < LodList.Count - 1; i++)
			{
				lodDist = LodList[i].Distance;
				if (lodDist * lodDist >= sqrDist)
				{
					aimContext.Sensor = ((LodList[i].Sensor == null) ? aimContext.Sensor : LodList[i].Sensor);
					break;
				}
			}
			if (DeactivateOnLast)
			{
				lodDist = LodList[LodList.Count - 2].Distance;
				aimContext.enabled = !(lodDist * lodDist <= sqrDist);
			}
		}
	}
}
