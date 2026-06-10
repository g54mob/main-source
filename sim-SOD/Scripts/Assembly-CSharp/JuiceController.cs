using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

public class JuiceController : MonoBehaviour
{
	[Serializable]
	public class JuiceElement
	{
		public RectTransform transformElement;

		public Image imageElement;

		public RawImage rawImageElement;

		public CanvasRenderer renderer;

		public Color originalColour;

		[Tooltip("Get the original colours of images and raw images at the start")]
		public bool getNormalColourAtStart;

		public Vector3 originalLocalPos;

		public Vector3 originalLocalRot;

		public Vector3 originalLocalScale;

		public bool getNormalTransformAtStart;
	}

	[Header("Elements")]
	[ReorderableList]
	public List<JuiceElement> elements;

	[Header("On Start")]
	public bool pulsateActive;

	public bool pulsateScale;

	public float pulsateProgress;

	public bool pulsateOnStart;

	public Color pulsateColour;

	public float pulsateSpeed;

	private bool flashActive;

	private float flashSpeed;

	public Color flashColour;

	private int cycle;

	private float flashProgress;

	private float flashF;

	private int flashRepeat;

	private bool onOff;

	public bool smoothPulsateOff;

	private bool nudgeActive;

	private bool nudgeState;

	private float nudgeProgress;

	private float amountToScale;

	private Vector3 desiredScale;

	private float amountToRotate;

	private bool nudgeEffectScale;

	private bool nudgeEffectRotation;

	public bool fancyAppearActive;

	public float appearSpeed;

	private float fancyAppearProgress;

	public bool fancyDisappearActive;

	public float disappearSpeed;

	private float fancyDisappearProgress;

	private void Start()
	{
	}

	public void GetOriginalRectSize()
	{
	}

	private void Update()
	{
	}

	public void Flash(int newRepeat, bool colourOverride, Color colour = default(Color), float speed = 10f)
	{
	}

	public void Pulsate(bool toggle, bool smoothOff = false)
	{
	}

	public void Nudge(Vector2 scaleRange, Vector2 rotationRange, bool updateOriginalPositionFirst = true, bool affectScale = true, bool affectRotation = true)
	{
	}

	public void FancyAppear(float newAppearSpeed = 2f)
	{
	}

	public void FancyDisappear(float newDisappearSpeed = 2f)
	{
	}

	private void OnDisable()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void Flash()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void PulsateToggle()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void Nudge()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void Appear()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void Disappear()
	{
	}
}
