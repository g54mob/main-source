using Assets.Scripts.Craft.Parts;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
	public class LoadingAircraftStatusScript : MonoBehaviour, IAircraftLoadingStatus
	{
		[SerializeField]
		private TextMeshPro _percentageText;

		private float _percentLoaded;

		public void OnLoadingProgress(float percentage)
		{
			_percentLoaded = percentage;
		}

		protected virtual void Update()
		{
			base.transform.Rotate(Vector3.up, Time.unscaledDeltaTime * 45f);
			_percentageText.text = $"{_percentLoaded * 100f:n0}%";
		}
	}
}
