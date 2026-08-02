using UnityEngine;

namespace Polyart
{
	public class Cull_Lights : MonoBehaviour
	{
		[SerializeField]
		private float lightCullDistance;

		[SerializeField]
		private float shadowCullDistance;

		[SerializeField]
		private bool shadowsEnabled;

		[SerializeField]
		private GameObject playerController;

		private Light lightSource;

		private void Awake()
		{
			lightSource = base.gameObject.GetComponent<Light>();
		}

		private void Start()
		{
		}

		private void Update()
		{
			float num = Vector3.Distance(playerController.transform.position, base.gameObject.transform.position);
			if (num <= lightCullDistance)
			{
				lightSource.enabled = true;
				if (num <= shadowCullDistance && shadowsEnabled)
				{
					lightSource.shadows = LightShadows.Soft;
				}
				else
				{
					lightSource.shadows = LightShadows.None;
				}
			}
			else
			{
				lightSource.enabled = false;
			}
		}
	}
}
