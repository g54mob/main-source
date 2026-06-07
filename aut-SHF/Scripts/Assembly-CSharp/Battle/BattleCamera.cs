using System.Collections.Generic;
using Libs;
using ScriptableObjects.ScriptableObjectScripts.Settings;
using UnityEngine;

namespace Battle
{
	[RequireComponent(typeof(Camera))]
	public class BattleCamera : SingletonMonoBehaviour<BattleCamera>
	{
		public IntervalCtrl intervalCtrlPrefab;

		public RectTransform canvasRect;

		public Camera battleCamera;

		public static Vector3 hitLocalPos;

		public static bool raycastOk;

		public static CameraShake cameraShake;

		private WaveInfoData _waveInfo;

		private IntervalCtrl _nowIntercalObj;

		private InputActionController input;

		private List<BaseMiracleSymbol> MiracleObjects;

		public bool NormalHitOk => false;

		public BaseMiracleSymbol UsingMiracle => null;

		private void Awake()
		{
		}

		public void Init()
		{
		}

		public void CreateMiracleObj(MiracleInfo info, bool useImmediately = true)
		{
		}

		public void SwitchMiracle()
		{
		}

		public void UpdateBattleCamera()
		{
		}

		private void OutputClickSpell()
		{
		}

		private void LateUpdate()
		{
		}
	}
}
