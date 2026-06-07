using DG.Tweening;
using UnityEngine;

public class FactoryCameraSettings : ScriptableObject
{
	public bool defaultModeIsOrthographic;

	[Header("Orthographic")]
	public Vector3 orthoPosition;

	public Quaternion orthoRotation;

	public float orthoNearClipPlane;

	public float defaultOrthographicSize;

	public float orthographicSizeMin;

	[Header("Perspective")]
	public Vector3 persPosition;

	public Quaternion persRotation;

	public float persNearClipPlane;

	[Header("WASDによるカメラ移動速度の補正値")]
	public float cameraSpeedCorrectionValue;

	[Header("PageUp/Downによるカメラズーム速度の補正値")]
	public float cameraZoomSpeedCorrectionValueMin;

	public float cameraZoomSpeedCorrectionValueMax;

	[Header("工場開始直後カメラのズーム")]
	public float startFieldOfView;

	[Header("工場標準カメラのズーム")]
	public float defaultFieldOfView;

	[Header("工場開始直後カメラの有効時間")]
	public float startToDefaultFovWait;

	public Ease startToDefaultFovEase;

	public float startToDefaultFovDuration;

	public float fieldOfViewMin;

	public float fieldOfViewMax;

	[Header("カメラの最大距離に対するオプションによる補正範囲\n((Max - Min) * value)の範囲をオプションで調整)\n最大値：1")]
	public float cameraDistanceCorrectionValue;

	[Space(24f)]
	public float cameraLrLimit;

	public float cameraUpLimit;

	public float cameraDownLimit;
}
