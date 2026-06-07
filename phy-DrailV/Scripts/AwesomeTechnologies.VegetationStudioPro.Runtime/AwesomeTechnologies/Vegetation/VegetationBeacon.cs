using System.Collections.Generic;
using AwesomeTechnologies.Utility;
using AwesomeTechnologies.VegetationStudio;
using UnityEngine;

namespace AwesomeTechnologies.Vegetation
{
	[HelpURL("http://www.awesometech.no/index.php/vegetation-beacon")]
	[ExecuteInEditMode]
	[AwesomeTechnologiesScriptOrder(99)]
	public class VegetationBeacon : MonoBehaviour
	{
		public float Radius = 5f;

		public AnimationCurve FalloffCurve = new AnimationCurve();

		public List<VegetationTypeSettings> VegetationTypeList = new List<VegetationTypeSettings>();

		private Vector3 _lastPosition;

		private Quaternion _lastRotation;

		private BeaconMaskArea _currentMaskArea;

		private bool _needInit;

		public void UpdateVegetationMask()
		{
			if (base.enabled && base.gameObject.activeSelf)
			{
				BeaconMaskArea beaconMaskArea = new BeaconMaskArea
				{
					Radius = Radius,
					Position = base.transform.position
				};
				beaconMaskArea.SetFalloutCurve(FalloffCurve.GenerateCurveArray(4096));
				beaconMaskArea.Init();
				AddVegetationTypes(beaconMaskArea);
				if (_currentMaskArea != null)
				{
					VegetationStudioManager.RemoveVegetationMask(_currentMaskArea);
					_currentMaskArea = null;
				}
				_currentMaskArea = beaconMaskArea;
				VegetationStudioManager.AddVegetationMask(beaconMaskArea);
			}
		}

		private void Start()
		{
			_lastPosition = base.transform.position;
			_lastRotation = base.transform.rotation;
		}

		private void OnEnable()
		{
			_needInit = true;
		}

		private void Update()
		{
			if (_lastPosition != base.transform.position || _lastRotation != base.transform.rotation)
			{
				UpdateVegetationMask();
				_lastPosition = base.transform.position;
				_lastRotation = base.transform.rotation;
			}
		}

		public void AddVegetationTypes(BaseMaskArea maskArea)
		{
			for (int i = 0; i <= VegetationTypeList.Count - 1; i++)
			{
				maskArea.VegetationTypeList.Add(new VegetationTypeSettings(VegetationTypeList[i]));
			}
		}

		private void Reset()
		{
			FalloffCurve.AddKey(0f, 1f);
			FalloffCurve.AddKey(1f, 0f);
		}

		private void OnDisable()
		{
			if (_currentMaskArea != null)
			{
				VegetationStudioManager.RemoveVegetationMask(_currentMaskArea);
				_currentMaskArea.Dispose();
				_currentMaskArea = null;
			}
		}

		private void LateUpdate()
		{
			if (_needInit)
			{
				_needInit = false;
				UpdateVegetationMask();
			}
		}
	}
}
