using UnityEngine;

namespace AwesomeTechnologies.Grass
{
	[ExecuteInEditMode]
	public class WindController : MonoBehaviour
	{
		public Texture WindWavesTexture;

		public float WindWavesSize = 10f;

		public float WindSpeedFactor = 1f;

		public WindZone WindZone;

		private void Reset()
		{
			FindWindZone();
			SetupWind();
		}

		private void SetupWind()
		{
			if (WindWavesTexture == null)
			{
				WindWavesTexture = (Texture2D)Resources.Load("PerlinSeamless", typeof(Texture2D));
			}
		}

		private void OnEnable()
		{
			FindWindZone();
		}

		private void OnRenderObject()
		{
			UpdateWind();
		}

		private void UpdateWind()
		{
			if ((bool)WindZone)
			{
				Vector3 forward = WindZone.transform.forward;
				Vector4 value = new Vector4(forward.x, Mathf.Abs(WindZone.windMain) * WindSpeedFactor * 10f, forward.z, WindWavesSize);
				Shader.SetGlobalVector("_AW_DIR", value);
				if ((bool)WindWavesTexture)
				{
					Shader.SetGlobalTexture("_AW_WavesTex", WindWavesTexture);
				}
			}
		}

		private void Update()
		{
			UpdateWind();
		}

		private void FindWindZone()
		{
			if (!WindZone)
			{
				WindZone = (WindZone)Object.FindObjectOfType(typeof(WindZone));
			}
		}
	}
}
