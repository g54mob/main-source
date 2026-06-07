using DV.Utils;
using UnityEngine;

public class FloatieWithAnimation : Floatie
{
	private const string ANIMATOR_STATE_INFO_NAME = "Open";

	[SerializeField]
	private Material customLineMaterial;

	[SerializeField]
	[Range(0f, 1f)]
	private float lineAppearenceThreshold = 0.5f;

	private bool usingCustomMaterial;

	private bool animationAllowsLine;

	private Animator animator;

	protected override bool CanDrawLine
	{
		get
		{
			if (drawLine)
			{
				return animationAllowsLine;
			}
			return false;
		}
	}

	protected override void Start()
	{
		animator = GetComponentInChildren<Animator>();
		if (animator == null)
		{
			Debug.LogError("FloatieWithAnimation doesn't have animator in children! Destroying self!");
			Object.Destroy(this);
			return;
		}
		if (!VRManager.IsVREnabled() && (bool)SingletonBehaviour<UiVisibilityManagerNonvr>.Instance && !SingletonBehaviour<UiVisibilityManagerNonvr>.Instance.GetVisible())
		{
			Object.Destroy(this);
			return;
		}
		base.Start();
		if (customLineMaterial != null)
		{
			lineMaterial = customLineMaterial;
			line.material = lineMaterial;
			usingCustomMaterial = true;
		}
	}

	protected override void Update()
	{
		if (!animationAllowsLine && animator.GetCurrentAnimatorStateInfo(0).IsName("Open") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= lineAppearenceThreshold)
		{
			animationAllowsLine = true;
		}
		base.Update();
	}

	public override void OnAboutToBeDestroyed()
	{
		drawLine = false;
		if ((bool)animator)
		{
			animator.SetBool("Open", value: false);
		}
	}

	protected override void SetLineColor()
	{
		if (!usingCustomMaterial)
		{
			base.SetLineColor();
		}
	}

	protected override void UpdateDismiss()
	{
		if (!VRManager.IsVREnabled() && !SingletonBehaviour<UiVisibilityManagerNonvr>.Instance.GetVisible())
		{
			Dismissed.Invoke();
			Destroy();
		}
		base.UpdateDismiss();
	}
}
