using System;
using UIScripts.InfoHandles;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utility;

namespace UIScripts
{
	public class UISynaps : PoolableItem<UISynaps>, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private GameObject hoverHolder;

		[SerializeField]
		private FloatValueTextHandle valueText;

		[SerializeField]
		private TooltipTrigger parentDifferenceHelper;

		[SerializeField]
		private RectTransform rt;

		[SerializeField]
		private Image img;

		[NonSerialized]
		public float value;

		[NonSerialized]
		public int index;

		private static float disabledAlpha = 0.25f;

		[NonSerialized]
		public bool disabled;

		[NonSerialized]
		public float thickness;

		private Material mat;

		[NonSerialized]
		public UINeuron nodeIn;

		[NonSerialized]
		public UINeuron nodeOut;

		private Transform anchorIn;

		private Transform anchorOut;

		[NonSerialized]
		public float alphaFloat = 1f;

		[NonSerialized]
		public bool hidden;

		[NonSerialized]
		private bool realTime;

		[NonSerialized]
		public long inov;

		private static readonly int InputActivation = Shader.PropertyToID("_inputActivation");

		private static readonly int Color = Shader.PropertyToID("_Color");

		private static readonly int AbsoluteStrength = Shader.PropertyToID("_absoluteStrength");

		private static readonly int Width = Shader.PropertyToID("_width");

		private static readonly int Selected = Shader.PropertyToID("_Selected");

		private static readonly int HighlightAmount = Shader.PropertyToID("_HighlightAmount");

		public void InitSynaps(bool animate = false)
		{
			hidden = false;
			img = GetComponent<Image>();
			rt = GetComponent<RectTransform>();
			realTime = animate;
			img.material = UnityEngine.Object.Instantiate(img.material);
			mat = img.material;
			SetDifferent(val: false);
			hoverHolder.SetActive(value: false);
			parentDifferenceHelper.enabled = false;
		}

		public override void Initialize()
		{
			base.Initialize();
			InitSynaps();
		}

		public override void WakeUp()
		{
			base.WakeUp();
			SetDifferent(val: false);
		}

		public override void Retire()
		{
			base.Retire();
			ResetDiff();
			hoverHolder.SetActive(value: false);
		}

		public void OnPointerEnter(PointerEventData _eventData)
		{
			hoverHolder.SetActive(value: true);
			base.transform.SetAsLastSibling();
		}

		public void OnPointerExit(PointerEventData _eventData)
		{
			hoverHolder.SetActive(value: false);
		}

		public void SetValue(float _val, int _index, long _inov, bool _enabled = true)
		{
			value = _val;
			disabled = !_enabled;
			index = _index;
			inov = _inov;
			valueText.UpdateValue(value);
			mat.SetColor(Color, GetColorGradiant(value, alphaFloat, _enabled));
			mat.SetFloat(AbsoluteStrength, Mathf.Abs(_val));
			SetSynapseThickness(value);
		}

		public void SetDifferent(bool val, float amount = 0f)
		{
			parentDifferenceHelper.enabled = val;
			if (!val || Mathf.Approximately(amount, 0f))
			{
				mat.SetInt(Selected, 0);
				return;
			}
			mat.SetInt(Selected, 1);
			mat.SetFloat(HighlightAmount, amount);
		}

		public void SetNew(float dist, float contrib)
		{
			SetDifferent(val: true, 1f);
			parentDifferenceHelper.UpdateText("New from compared", $"This is a new Connection\nResulting Genetic Distance: {dist:F3}\nContribution to speciation: +{100f * contrib:F1}%");
		}

		public void SetToggled(float dist, float contrib)
		{
			SetDifferent(val: true, 0.75f);
			parentDifferenceHelper.UpdateText("Toggled from compared", $"Connection was Toggled (either disabled or re-enabled)\nResulting Genetic Distance: {dist:F3}\nContribution to speciation: +{100f * contrib:F1}%");
		}

		public void SetDiff(float val, float dist, float contrib, float highlight)
		{
			SetDifferent(val: true, highlight);
			parentDifferenceHelper.UpdateText("Weight Difference from compared", string.Format("Delta: {0}{1}\nResulting Genetic Distance: {2:F3}\nContribution to speciation: +{3:F1}%", (val > 0f) ? "+" : "", val, dist, 100f * contrib));
		}

		public void ResetDiff()
		{
			SetDifferent(val: false);
		}

		public void ToggleShowDisabled()
		{
			if (disabled)
			{
				if (!hidden)
				{
					hidden = true;
					base.gameObject.SetActive(value: false);
				}
				else
				{
					hidden = false;
					base.gameObject.SetActive(value: true);
				}
			}
		}

		public void Update()
		{
			if (!(anchorIn == null) && anchorIn.hasChanged && !(anchorOut == null) && anchorIn.hasChanged)
			{
				UpdatePosition();
				if (realTime)
				{
					mat.SetFloat(InputActivation, Mathf.Abs(nodeIn.value));
				}
			}
		}

		public static Color GetColorGradiant(float _val, float alpha, bool enabledConnection = true)
		{
			float num = (Mathf.Exp(_val) - 1f) / (1f + Mathf.Exp(_val));
			if (!enabledConnection)
			{
				return new Color(1f, 1f, 1f, disabledAlpha);
			}
			if (_val >= 0f)
			{
				return new Color(1f - num, 1f, 1f - num, alpha);
			}
			return new Color(1f, num + 1f, num + 1f, alpha);
		}

		private void SetSynapseThickness(float strength)
		{
			float num = Mathf.Clamp(Mathf.Abs(strength), 0f, 25f);
			thickness = (Mathf.Exp(num / 2f) - 1f) / (1f + Mathf.Exp(num / 2f)) * 6f + 10f;
			img.pixelsPerUnitMultiplier = 7f / thickness;
			rt.sizeDelta = new Vector2(rt.sizeDelta.x, thickness);
		}

		public void SetAnchorIn(UINeuron _anchorIn)
		{
			nodeIn = _anchorIn;
			anchorIn = _anchorIn.transform;
		}

		public void SetAnchorOut(UINeuron _anchorOut)
		{
			nodeOut = _anchorOut;
			anchorOut = _anchorOut.transform;
		}

		public void setAlphaLow(bool val)
		{
			Color color = img.color;
			if (val && !disabled)
			{
				alphaFloat = 0.01f;
				color.a = alphaFloat;
			}
			else if (!disabled)
			{
				alphaFloat = 1f;
				color.a = alphaFloat;
			}
			img.color = color;
		}

		public void UpdatePosition()
		{
			rt.anchoredPosition = anchorIn.localPosition;
			Vector3 vector = anchorOut.localPosition - anchorIn.localPosition;
			rt.sizeDelta = new Vector2(vector.magnitude, rt.sizeDelta.y);
			rt.eulerAngles = new Vector3(0f, 0f, Mathf.Atan2(vector.y, vector.x) * 57.29578f);
		}

		private void OnDestroy()
		{
			UnityEngine.Object.Destroy(mat);
		}
	}
}
