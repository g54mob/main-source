using Battle;
using UnityEngine;

namespace ScriptableObjects.ScriptableObjectScripts.Settings
{
	public class TutorialSetting : ScriptableObject
	{
		[Label("最初のチュートリアルSection")]
		[Tooltip("導入で自動的に遷移するチュートリアルSection")]
		public eTutorialSectionId firstTutorialSectionId;

		[Header("チュートリアル初期カメラ設定")]
		[Label("カメラ位置")]
		public Vector3 initFixPosition;

		[Label("カメラ回転")]
		public Quaternion initFixRotation;

		[Label("カメラFOV")]
		public float initFixFOV;

		[Label("カメラ移動時間")]
		public float moveCameraDuration;

		[Space]
		[Label("大システムクリック可能秒数")]
		public float clickableMajorHead;

		[Label("中システムクリック可能秒数")]
		public float clickableCrossHead;

		public Vector2Int tutorialMapOffset;
	}
}
