using UnityEngine;

namespace DeepTraffic
{
	public class CarAI : ActiveComponent
	{
		[SceneBind("Helm/HelmLayer/HighlightedHelm")]
		private Transform helmHighlightTransform;

		[SceneBind("CarLayer/HighlightedHelm")]
		private Transform highlightedHelmWay;

		[SceneBind("CarLayer/HighlightedSel")]
		private Transform highlightedSelWay;

		[SceneBind("CarLayer/HighlightedSpeed")]
		private Transform highlightedSpeedWay;

		[SceneBind("CarLayer/NormalHelm")]
		private Transform normalHelmWay;

		[SceneBind("CarLayer/NormalSel")]
		private Transform normalSelWay;

		[SceneBind("CarLayer/NormalSpeed")]
		private Transform normalSpeedWay;

		[SceneBind("PedalSel/HighlightedLayer")]
		private Transform pedalSelHighlightTransform;

		[SceneBind("SpeedPedal/HighlightedLayer")]
		private Transform speedPedalHighlightTransform;

		[SceneBind("Helm/HelmLayer")]
		private Transform helmTransform;

		public bool HighlightHelm
		{
			get
			{
				return helmHighlightTransform.gameObject.activeSelf;
			}
			set
			{
				helmHighlightTransform.gameObject.SetActive(value);
				normalHelmWay.gameObject.SetActive(!value);
				highlightedHelmWay.gameObject.SetActive(value);
			}
		}

		public bool HighlightPedalSel
		{
			get
			{
				return pedalSelHighlightTransform.gameObject.activeSelf;
			}
			set
			{
				pedalSelHighlightTransform.gameObject.SetActive(value);
				normalSelWay.gameObject.SetActive(!value);
				highlightedSelWay.gameObject.SetActive(value);
			}
		}

		public bool HighlightSpeedPedal
		{
			get
			{
				return speedPedalHighlightTransform.gameObject.activeSelf;
			}
			set
			{
				speedPedalHighlightTransform.gameObject.SetActive(value);
				normalSpeedWay.gameObject.SetActive(!value);
				highlightedSpeedWay.gameObject.SetActive(value);
			}
		}

		public bool HighlightGlobal
		{
			get
			{
				if (!HighlightHelm && !HighlightPedalSel)
				{
					return HighlightSpeedPedal;
				}
				return true;
			}
			set
			{
				HighlightHelm = value;
				HighlightPedalSel = value;
				HighlightSpeedPedal = value;
			}
		}

		public void SetHelmRotate(int val)
		{
			helmTransform.eulerAngles = new Vector3(0f, 0f, -30 * val);
		}

		protected override void OnInit()
		{
			base.OnInit();
			SceneBindContainer.BindObjects(this, base.transform);
			HighlightGlobal = false;
		}
	}
}
