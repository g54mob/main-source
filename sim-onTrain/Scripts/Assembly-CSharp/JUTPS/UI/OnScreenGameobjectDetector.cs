using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace JUTPS.UI
{
	public class OnScreenGameobjectDetector : MonoBehaviour
	{
		[Header("Detect")]
		[SerializeField]
		private string[] DetectGameobjectWithTags = new string[1] { "Untagged" };

		[SerializeField]
		private float DetectRadius = 2f;

		[SerializeField]
		private float RefreshRate = 0.2f;

		[SerializeField]
		private LayerMask Layer;

		public GameObject DetectorCenter;

		[Header("Warnings")]
		[SerializeField]
		private GameObject WarningPrefab;

		[SerializeField]
		private Vector3 PositionOffset;

		private Collider[] detectedObjects = new Collider[0];

		private List<GameObject> warnings = new List<GameObject>();

		private bool isInitialized;

		private void OnEnable()
		{
			Singleton<TSNetworkObjetManager>.Instance.OnServerInitialize.AddListener(Initialize);
		}

		private void OnDisable()
		{
			Singleton<TSNetworkObjetManager>.Instance.OnServerInitialize.RemoveListener(Initialize);
		}

		private void Initialize(TSPlayerController tsPlayer)
		{
			if (DetectorCenter == null)
			{
				DetectorCenter = tsPlayer.gameObject;
			}
			InvokeRepeating("Detect", RefreshRate, RefreshRate);
		}

		private void LateUpdate()
		{
			RefreshWarningsCount();
			RefreshWarningPositions();
		}

		private void RefreshWarningPositions()
		{
			if (warnings.Count != 0 && detectedObjects.Length != 0)
			{
				for (int i = 0; i < warnings.Count && !(warnings[i] == null) && !(detectedObjects[i] == null); i++)
				{
					UIElementToWorldPosition.SetUIWorldPosition(warnings[i], detectedObjects[i].transform.position, PositionOffset);
				}
			}
		}

		private void RefreshWarningsCount()
		{
			if (detectedObjects.Length == 0)
			{
				DisableAllWarnings();
			}
			if (warnings.Count != detectedObjects.Length)
			{
				GameObject[] array = warnings.ToArray();
				for (int i = 0; i < array.Length; i++)
				{
					Object.Destroy(array[i]);
				}
				warnings.Clear();
				Collider[] array2 = detectedObjects;
				for (int i = 0; i < array2.Length; i++)
				{
					_ = array2[i];
					GameObject item = Object.Instantiate(WarningPrefab, Vector3.zero, WarningPrefab.transform.rotation, base.transform);
					warnings.Add(item);
				}
			}
		}

		private void DisableAllWarnings()
		{
			GameObject[] array = warnings.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetActive(value: true);
			}
		}

		private void Detect()
		{
			List<Collider> list = Physics.OverlapSphere(DetectorCenter.transform.position + base.transform.up, DetectRadius, Layer).ToList();
			Collider[] array = list.ToArray();
			foreach (Collider collider in array)
			{
				if (!TheTagMatches(collider.tag))
				{
					list.Remove(collider);
				}
			}
			detectedObjects = list.ToArray();
		}

		public bool TheTagMatches(string objectTag)
		{
			bool result = false;
			string[] detectGameobjectWithTags = DetectGameobjectWithTags;
			foreach (string text in detectGameobjectWithTags)
			{
				if (objectTag == text)
				{
					result = true;
				}
			}
			return result;
		}
	}
}
