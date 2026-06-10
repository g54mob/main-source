using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "cutscene_data", menuName = "Database/Cut Scene")]
public class CutScenePreset : SoCustomComparison
{
	[Serializable]
	public class CutSceneElement
	{
		public string name;

		public bool disable;

		public ElementType elementType;

		[Space(5f)]
		public List<CameraMovement> movement;

		public AnimationCurve lerpPositionGraph;

		public AnimationCurve lerpRotationGraph;

		[Space(7f)]
		public string ddsMessage;

		public float messageDelay;
	}

	public enum ElementType
	{
		newShot = 0,
		ddsMessage = 1
	}

	public enum OnEndScene
	{
		resumeGameplay = 0,
		startGame = 1,
		endGame = 2
	}

	public enum AnchorType
	{
		blockCorner = 0,
		middle = 1
	}

	[Serializable]
	public class CameraMovement
	{
		public float atDuration;

		public Vector3 camPos;

		public Vector3 camEuler;

		public AnchorType anchor;

		public bool overridePosGraph;

		[ShowIf("overridePosGraph")]
		public AnimationCurve lerpPositionGraphOverride;

		public bool overrideRotGraph;

		[ShowIf("overrideRotGraph")]
		public AnimationCurve lerpRotationGraphOverride;
	}

	[Header("Timeline")]
	public List<CutSceneElement> elementList;

	[Space(7f)]
	public bool fadeIn;

	[ShowIf("fadeIn")]
	public float fadeInTime;

	public bool fadeOut;

	[ShowIf("fadeOut")]
	public float fadeOutTime;

	[Space(7f)]
	public Sprite displayImage;

	public float imageFadeIn;

	public float imageFadeInSpeed;

	public float imageFadeOut;

	public float imageFadeOutSpeed;

	[Header("Settings")]
	public bool disableAISpeech;

	public OnEndScene onEnd;

	[Button(null, EButtonEnableMode.Always)]
	public void RecordCurrentPositionToNewShot()
	{
	}
}
