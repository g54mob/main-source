using System.ComponentModel;
using Rewired.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.Internal
{
	[Browsable(false)]
	[AddComponentMenu("")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class GUIText : MonoBehaviour
	{
		private string LbcNCRHEGOpNIMcigJwFbZvWOvLL;

		private GUIStyle yjUhtIgPEhXxTIqaZhmGwEdkjQVH;

		private TextAnchor YnJNLrWgQqJOdgAxCDIXLHeTEhzI;

		private TextAlignment HBMVJdVHapyOYnIUurDQCXMOdLwp;

		private float LOqlhePoTJEtxHlgPNPvhFKycbJcb;

		private Font FGUURjAltZybJiXKVkypdVaBsEgi;

		private int zFPQOavuWSQuUDAUkSOqZyFDBYPC = -1;

		private FontStyle lQlpCQSlWXmojPfOycleZqFURjap;

		private Color hpBkYlGdUiqXKLSmyAovvZOyagth = Color.white;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Vector2 _pixelOffset;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _useUnityUI;

		private bool hQGAuPQdGCzpktiiOhGtvBDICvVGA;

		private bool GFudFYlfPuLyLJCzGRDpdyoRrDcn;

		private bool CRXXXFnKCKcqkpCjQiuGFNZadee;

		private bool gUjbjFNGXnWpGpNrPgoxqnOMBIUP;

		private bool qffOalsDiMjLUBlETIXPDfedYOFfB;

		private bool edLtSeikFcGTmhYFGxAXEWZUVcxo;

		private bool qxlPpPOHEHxFYZbtioHRFbVcWmPd;

		private Text AYpTMmojcDMKSabmNtospJyjVIfv;

		private bool SumkAWfEnnZECnbpzyQNNjCWiMCX;

		private bool bUIAuFXIuwXUNYsjTpvTBScqlQnQ;

		public string text
		{
			get
			{
				return LbcNCRHEGOpNIMcigJwFbZvWOvLL;
			}
			set
			{
				LbcNCRHEGOpNIMcigJwFbZvWOvLL = value;
			}
		}

		public TextAnchor anchor
		{
			get
			{
				return YnJNLrWgQqJOdgAxCDIXLHeTEhzI;
			}
			set
			{
				YnJNLrWgQqJOdgAxCDIXLHeTEhzI = value;
				hQGAuPQdGCzpktiiOhGtvBDICvVGA = true;
				if (yjUhtIgPEhXxTIqaZhmGwEdkjQVH != null)
				{
					yjUhtIgPEhXxTIqaZhmGwEdkjQVH.alignment = value;
				}
			}
		}

		public TextAlignment alignment
		{
			get
			{
				return HBMVJdVHapyOYnIUurDQCXMOdLwp;
			}
			set
			{
				HBMVJdVHapyOYnIUurDQCXMOdLwp = value;
				GFudFYlfPuLyLJCzGRDpdyoRrDcn = true;
			}
		}

		public float lineSpacing
		{
			get
			{
				return LOqlhePoTJEtxHlgPNPvhFKycbJcb;
			}
			set
			{
				LOqlhePoTJEtxHlgPNPvhFKycbJcb = value;
				CRXXXFnKCKcqkpCjQiuGFNZadee = true;
				_ = yjUhtIgPEhXxTIqaZhmGwEdkjQVH;
			}
		}

		public Font font
		{
			get
			{
				return FGUURjAltZybJiXKVkypdVaBsEgi;
			}
			set
			{
				gUjbjFNGXnWpGpNrPgoxqnOMBIUP = true;
				FGUURjAltZybJiXKVkypdVaBsEgi = value;
				if (yjUhtIgPEhXxTIqaZhmGwEdkjQVH != null)
				{
					yjUhtIgPEhXxTIqaZhmGwEdkjQVH.font = value;
				}
			}
		}

		public int fontSize
		{
			get
			{
				return zFPQOavuWSQuUDAUkSOqZyFDBYPC;
			}
			set
			{
				zFPQOavuWSQuUDAUkSOqZyFDBYPC = value;
				qffOalsDiMjLUBlETIXPDfedYOFfB = true;
				if (yjUhtIgPEhXxTIqaZhmGwEdkjQVH != null)
				{
					yjUhtIgPEhXxTIqaZhmGwEdkjQVH.fontSize = value;
				}
			}
		}

		public FontStyle fontStyle
		{
			get
			{
				return lQlpCQSlWXmojPfOycleZqFURjap;
			}
			set
			{
				lQlpCQSlWXmojPfOycleZqFURjap = value;
				edLtSeikFcGTmhYFGxAXEWZUVcxo = true;
				if (yjUhtIgPEhXxTIqaZhmGwEdkjQVH != null)
				{
					yjUhtIgPEhXxTIqaZhmGwEdkjQVH.fontStyle = value;
				}
			}
		}

		public Color color
		{
			get
			{
				return hpBkYlGdUiqXKLSmyAovvZOyagth;
			}
			set
			{
				hpBkYlGdUiqXKLSmyAovvZOyagth = value;
				qxlPpPOHEHxFYZbtioHRFbVcWmPd = true;
				if (yjUhtIgPEhXxTIqaZhmGwEdkjQVH != null)
				{
					yjUhtIgPEhXxTIqaZhmGwEdkjQVH.normal.textColor = value;
				}
			}
		}

		public Vector2 pixelOffset
		{
			get
			{
				return _pixelOffset;
			}
			set
			{
				_pixelOffset = value;
			}
		}

		public bool useUnityUI
		{
			get
			{
				return _useUnityUI;
			}
			set
			{
				if (_useUnityUI != value)
				{
					_useUnityUI = value;
					SumkAWfEnnZECnbpzyQNNjCWiMCX = value;
					if (value)
					{
						jXCqUeVasXSTEVpsEziAguMrqAuW();
					}
					else
					{
						sOqnTSHNNBeJSKqqLYtfMsTjbtXZA();
					}
				}
			}
		}

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			bUIAuFXIuwXUNYsjTpvTBScqlQnQ = true;
		}

		[CustomObfuscation(rename = false)]
		private void Start()
		{
			SumkAWfEnnZECnbpzyQNNjCWiMCX = _useUnityUI;
			if (_useUnityUI)
			{
				jXCqUeVasXSTEVpsEziAguMrqAuW();
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			if (!_useUnityUI)
			{
				if (yjUhtIgPEhXxTIqaZhmGwEdkjQVH == null)
				{
					ItjWrhIcgUmIZxmkqndshywMsPoU();
				}
				if (!string.IsNullOrEmpty(LbcNCRHEGOpNIMcigJwFbZvWOvLL))
				{
					Vector2 vector = base.transform.localPosition;
					GUI.Label(new Rect(vector.x * (float)Screen.width + _pixelOffset.x, vector.y * (float)Screen.height + _pixelOffset.y, MathTools.Clamp((float)Screen.width - vector.x * (float)Screen.width, 0f, float.MaxValue), MathTools.Clamp((float)Screen.height - vector.y * (float)Screen.height, 0f, float.MaxValue)), LbcNCRHEGOpNIMcigJwFbZvWOvLL, yjUhtIgPEhXxTIqaZhmGwEdkjQVH);
				}
			}
		}

		[CustomObfuscation(rename = false)]
		private void Update()
		{
			if (!_useUnityUI)
			{
				return;
			}
			if (AYpTMmojcDMKSabmNtospJyjVIfv == null)
			{
				Logger.LogError("Text component has been deleted.");
				return;
			}
			RectTransform component = AYpTMmojcDMKSabmNtospJyjVIfv.GetComponent<RectTransform>();
			if (component.anchoredPosition != _pixelOffset)
			{
				component.anchoredPosition = _pixelOffset;
			}
			AYpTMmojcDMKSabmNtospJyjVIfv.text = LbcNCRHEGOpNIMcigJwFbZvWOvLL;
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			if (bUIAuFXIuwXUNYsjTpvTBScqlQnQ && _useUnityUI != SumkAWfEnnZECnbpzyQNNjCWiMCX)
			{
				SumkAWfEnnZECnbpzyQNNjCWiMCX = _useUnityUI;
				if (_useUnityUI)
				{
					jXCqUeVasXSTEVpsEziAguMrqAuW();
				}
				else
				{
					sOqnTSHNNBeJSKqqLYtfMsTjbtXZA();
				}
			}
		}

		private void jXCqUeVasXSTEVpsEziAguMrqAuW()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			if (UnityTools.GetComponentInSelfOrParents<Canvas>(base.transform) == null)
			{
				GameObject gameObject;
				if (base.transform.root == base.transform)
				{
					gameObject = new GameObject("Canvas");
					base.transform.SetParent(gameObject.transform, worldPositionStays: true);
				}
				else
				{
					gameObject = base.transform.root.gameObject;
				}
				gameObject.AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
				if (!(gameObject.GetComponent<CanvasScaler>() != null))
				{
					gameObject.AddComponent<CanvasScaler>();
				}
				else
				{
					gameObject.GetComponent<CanvasScaler>();
				}
			}
			AYpTMmojcDMKSabmNtospJyjVIfv = GetComponent<Text>();
			if (!(AYpTMmojcDMKSabmNtospJyjVIfv == null))
			{
				return;
			}
			RectTransform rectTransform = base.gameObject.AddComponent<RectTransform>();
			rectTransform.anchorMax = new Vector2(1f, 1f);
			rectTransform.anchorMin = new Vector2(0f, 0f);
			rectTransform.localPosition = Vector2.zero;
			rectTransform.anchoredPosition = Vector2.zero;
			rectTransform.sizeDelta = Vector3.zero;
			AYpTMmojcDMKSabmNtospJyjVIfv = base.gameObject.AddComponent<Text>();
			AYpTMmojcDMKSabmNtospJyjVIfv.color = Color.white;
			if (_useUnityUI)
			{
				try
				{
					AYpTMmojcDMKSabmNtospJyjVIfv.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
				}
				catch
				{
					try
					{
						AYpTMmojcDMKSabmNtospJyjVIfv.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
					}
					catch
					{
						Logger.LogError("No default font found for GUIText.");
					}
				}
			}
			AYpTMmojcDMKSabmNtospJyjVIfv.fontSize = 13;
			if (hQGAuPQdGCzpktiiOhGtvBDICvVGA)
			{
				AYpTMmojcDMKSabmNtospJyjVIfv.alignment = YnJNLrWgQqJOdgAxCDIXLHeTEhzI;
			}
			else
			{
				YnJNLrWgQqJOdgAxCDIXLHeTEhzI = AYpTMmojcDMKSabmNtospJyjVIfv.alignment;
			}
			if (gUjbjFNGXnWpGpNrPgoxqnOMBIUP)
			{
				AYpTMmojcDMKSabmNtospJyjVIfv.font = FGUURjAltZybJiXKVkypdVaBsEgi;
			}
			else
			{
				FGUURjAltZybJiXKVkypdVaBsEgi = AYpTMmojcDMKSabmNtospJyjVIfv.font;
			}
			if (qffOalsDiMjLUBlETIXPDfedYOFfB)
			{
				AYpTMmojcDMKSabmNtospJyjVIfv.fontSize = zFPQOavuWSQuUDAUkSOqZyFDBYPC;
			}
			else
			{
				zFPQOavuWSQuUDAUkSOqZyFDBYPC = AYpTMmojcDMKSabmNtospJyjVIfv.fontSize;
			}
			if (edLtSeikFcGTmhYFGxAXEWZUVcxo)
			{
				AYpTMmojcDMKSabmNtospJyjVIfv.fontStyle = lQlpCQSlWXmojPfOycleZqFURjap;
			}
			else
			{
				lQlpCQSlWXmojPfOycleZqFURjap = AYpTMmojcDMKSabmNtospJyjVIfv.fontStyle;
			}
			if (qxlPpPOHEHxFYZbtioHRFbVcWmPd)
			{
				AYpTMmojcDMKSabmNtospJyjVIfv.color = hpBkYlGdUiqXKLSmyAovvZOyagth;
			}
			else
			{
				hpBkYlGdUiqXKLSmyAovvZOyagth = AYpTMmojcDMKSabmNtospJyjVIfv.color;
			}
		}

		private void sOqnTSHNNBeJSKqqLYtfMsTjbtXZA()
		{
			if (Application.isPlaying)
			{
				if (AYpTMmojcDMKSabmNtospJyjVIfv != null)
				{
					AYpTMmojcDMKSabmNtospJyjVIfv.text = string.Empty;
				}
				AYpTMmojcDMKSabmNtospJyjVIfv = null;
			}
		}

		private void ItjWrhIcgUmIZxmkqndshywMsPoU()
		{
			yjUhtIgPEhXxTIqaZhmGwEdkjQVH = new GUIStyle(GUI.skin.label);
			if (hQGAuPQdGCzpktiiOhGtvBDICvVGA)
			{
				yjUhtIgPEhXxTIqaZhmGwEdkjQVH.alignment = YnJNLrWgQqJOdgAxCDIXLHeTEhzI;
			}
			else
			{
				YnJNLrWgQqJOdgAxCDIXLHeTEhzI = yjUhtIgPEhXxTIqaZhmGwEdkjQVH.alignment;
			}
			if (gUjbjFNGXnWpGpNrPgoxqnOMBIUP)
			{
				yjUhtIgPEhXxTIqaZhmGwEdkjQVH.font = FGUURjAltZybJiXKVkypdVaBsEgi;
			}
			else
			{
				FGUURjAltZybJiXKVkypdVaBsEgi = yjUhtIgPEhXxTIqaZhmGwEdkjQVH.font;
			}
			if (qffOalsDiMjLUBlETIXPDfedYOFfB)
			{
				yjUhtIgPEhXxTIqaZhmGwEdkjQVH.fontSize = zFPQOavuWSQuUDAUkSOqZyFDBYPC;
			}
			else
			{
				zFPQOavuWSQuUDAUkSOqZyFDBYPC = yjUhtIgPEhXxTIqaZhmGwEdkjQVH.fontSize;
			}
			if (edLtSeikFcGTmhYFGxAXEWZUVcxo)
			{
				yjUhtIgPEhXxTIqaZhmGwEdkjQVH.fontStyle = lQlpCQSlWXmojPfOycleZqFURjap;
			}
			else
			{
				lQlpCQSlWXmojPfOycleZqFURjap = yjUhtIgPEhXxTIqaZhmGwEdkjQVH.fontStyle;
			}
			if (qxlPpPOHEHxFYZbtioHRFbVcWmPd)
			{
				yjUhtIgPEhXxTIqaZhmGwEdkjQVH.normal.textColor = hpBkYlGdUiqXKLSmyAovvZOyagth;
			}
			else
			{
				hpBkYlGdUiqXKLSmyAovvZOyagth = yjUhtIgPEhXxTIqaZhmGwEdkjQVH.normal.textColor;
			}
		}

		[CustomObfuscation(rename = false)]
		internal static GUIText GetOrAddComponent(GameObject gameObject)
		{
			if (gameObject == null)
			{
				return null;
			}
			GUIText gUIText = gameObject.GetComponent<GUIText>();
			if (gUIText == null)
			{
				gUIText = gameObject.AddComponent<GUIText>();
			}
			return gUIText;
		}

		[CustomObfuscation(rename = false)]
		internal static GUIText CreateLogger(GameObject gameObject)
		{
			if (gameObject == null)
			{
				return null;
			}
			GUIText orAddComponent = GetOrAddComponent(gameObject);
			orAddComponent.anchor = TextAnchor.LowerLeft;
			return orAddComponent;
		}
	}
}
