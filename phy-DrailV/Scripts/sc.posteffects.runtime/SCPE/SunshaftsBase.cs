using UnityEngine;

namespace SCPE
{
	public class SunshaftsBase
	{
		public enum BlendMode
		{
			Additive = 0,
			Screen = 1
		}

		public enum SunShaftsResolution
		{
			High = 1,
			Normal = 2,
			Low = 3
		}

		public enum Pass
		{
			SkySource = 0,
			RadialBlur = 1,
			Blend = 2
		}

		public static void AddShaftCaster()
		{
			GameObject gameObject = null;
			if ((bool)GameObject.Find("Directional Light"))
			{
				gameObject = GameObject.Find("Directional Light");
			}
			if (!gameObject && (bool)GameObject.Find("Directional light"))
			{
				gameObject = GameObject.Find("Directional light");
			}
			if (!gameObject)
			{
				Debug.LogError("<b>Sunshafts:</b> No object with the name 'Directional Light' or 'Directional light' could be found");
				return;
			}
			SunshaftCaster sunshaftCaster = gameObject.GetComponent<SunshaftCaster>();
			if (!sunshaftCaster)
			{
				sunshaftCaster = gameObject.AddComponent<SunshaftCaster>();
				Debug.Log("\"SunshaftCaster\" component was added to the <b>" + sunshaftCaster.gameObject.name + "</b> GameObject", sunshaftCaster.gameObject);
			}
			if (!sunshaftCaster.enabled)
			{
				sunshaftCaster.enabled = true;
			}
		}
	}
}
