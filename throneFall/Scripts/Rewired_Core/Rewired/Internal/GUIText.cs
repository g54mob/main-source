using System.ComponentModel;
using Rewired.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.Internal
{
	[AddComponentMenu("")]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class GUIText : MonoBehaviour
	{
		private string bvBibYLBiANUAONRpIIYcQFevyCg;

		private GUIStyle ctFkBpfTPhheHkObScVpAfwYOIgYA;

		private TextAnchor BnaJWiPlojxPvwSqMvddAcqFHCfP;

		private TextAlignment YVUmKzQOQzXpkcjHyRbdZjTqBDIr;

		private float cABmTiYYPhgSWOoDzqjBEQiclaYr;

		private Font UyabgbInGPgtNxItpCWipvYLVQEE;

		private int xiuTMayunLuHguJcQnCdmkRJTZBA = -1;

		private FontStyle djxarEJVwDcIMwmaxNhOQpQGiwToA;

		private Color agtehGiccmKZGEZXmXDnUPYeQANRA = Color.white;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Vector2 _pixelOffset;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useUnityUI;

		private bool sdrHcqczldKzcfdolbsJgnqTyFzSA;

		private bool KAKFbcPOGVOUvwfTyvGZzhZNmYNh;

		private bool cmYvyovTJiuWdlmqNpXcsxfGffCc;

		private bool zirsjHgAQurekicigFrdRqzNwKNu;

		private bool DnoqNEAJhuEMmaABrQBgqCcmQvMI;

		private bool XlRsEXwmSVjfSNhnccLxhFZXmPsE;

		private bool KZmByHtklAbKFFsdpaXFSfYoyzwPA;

		private Text vxvEYZXzFlMdBMKqpBAcrivicUBCA;

		private bool pFXeETfhuqWOmDhSDyIkSDPdTMxF;

		private bool DZmYLnNmFltaHWAnPIiIaEVhGrOy;

		public string text
		{
			get
			{
				return bvBibYLBiANUAONRpIIYcQFevyCg;
			}
			set
			{
				bvBibYLBiANUAONRpIIYcQFevyCg = value;
			}
		}

		public TextAnchor anchor
		{
			get
			{
				return BnaJWiPlojxPvwSqMvddAcqFHCfP;
			}
			set
			{
				BnaJWiPlojxPvwSqMvddAcqFHCfP = value;
				sdrHcqczldKzcfdolbsJgnqTyFzSA = true;
				if (ctFkBpfTPhheHkObScVpAfwYOIgYA != null)
				{
					ctFkBpfTPhheHkObScVpAfwYOIgYA.alignment = value;
				}
			}
		}

		public TextAlignment alignment
		{
			get
			{
				return YVUmKzQOQzXpkcjHyRbdZjTqBDIr;
			}
			set
			{
				YVUmKzQOQzXpkcjHyRbdZjTqBDIr = value;
				KAKFbcPOGVOUvwfTyvGZzhZNmYNh = true;
			}
		}

		public float lineSpacing
		{
			get
			{
				return cABmTiYYPhgSWOoDzqjBEQiclaYr;
			}
			set
			{
				cABmTiYYPhgSWOoDzqjBEQiclaYr = value;
				cmYvyovTJiuWdlmqNpXcsxfGffCc = true;
				_ = ctFkBpfTPhheHkObScVpAfwYOIgYA;
			}
		}

		public Font font
		{
			get
			{
				return UyabgbInGPgtNxItpCWipvYLVQEE;
			}
			set
			{
				zirsjHgAQurekicigFrdRqzNwKNu = true;
				UyabgbInGPgtNxItpCWipvYLVQEE = value;
				if (ctFkBpfTPhheHkObScVpAfwYOIgYA != null)
				{
					ctFkBpfTPhheHkObScVpAfwYOIgYA.font = value;
				}
			}
		}

		public int fontSize
		{
			get
			{
				return xiuTMayunLuHguJcQnCdmkRJTZBA;
			}
			set
			{
				xiuTMayunLuHguJcQnCdmkRJTZBA = value;
				DnoqNEAJhuEMmaABrQBgqCcmQvMI = true;
				if (ctFkBpfTPhheHkObScVpAfwYOIgYA != null)
				{
					ctFkBpfTPhheHkObScVpAfwYOIgYA.fontSize = value;
				}
			}
		}

		public FontStyle fontStyle
		{
			get
			{
				return djxarEJVwDcIMwmaxNhOQpQGiwToA;
			}
			set
			{
				djxarEJVwDcIMwmaxNhOQpQGiwToA = value;
				XlRsEXwmSVjfSNhnccLxhFZXmPsE = true;
				if (ctFkBpfTPhheHkObScVpAfwYOIgYA != null)
				{
					ctFkBpfTPhheHkObScVpAfwYOIgYA.fontStyle = value;
				}
			}
		}

		public Color color
		{
			get
			{
				return agtehGiccmKZGEZXmXDnUPYeQANRA;
			}
			set
			{
				agtehGiccmKZGEZXmXDnUPYeQANRA = value;
				KZmByHtklAbKFFsdpaXFSfYoyzwPA = true;
				if (ctFkBpfTPhheHkObScVpAfwYOIgYA != null)
				{
					ctFkBpfTPhheHkObScVpAfwYOIgYA.normal.textColor = value;
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
					pFXeETfhuqWOmDhSDyIkSDPdTMxF = value;
					if (value)
					{
						RlDtlRcsTiCxnWKqjOZZKnrHhzTn();
					}
					else
					{
						OEPRszlXLjeyNdZwzIMvjLulaRHCA();
					}
				}
			}
		}

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			DZmYLnNmFltaHWAnPIiIaEVhGrOy = true;
		}

		[CustomObfuscation(rename = false)]
		private void Start()
		{
			pFXeETfhuqWOmDhSDyIkSDPdTMxF = _useUnityUI;
			if (_useUnityUI)
			{
				RlDtlRcsTiCxnWKqjOZZKnrHhzTn();
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			if (!_useUnityUI)
			{
				if (ctFkBpfTPhheHkObScVpAfwYOIgYA == null)
				{
					FezdmQUJZxrpJMGFuUKYlonWhLWY();
				}
				if (!string.IsNullOrEmpty(bvBibYLBiANUAONRpIIYcQFevyCg))
				{
					Vector2 vector = base.transform.localPosition;
					GUI.Label(new Rect(vector.x * (float)Screen.width + _pixelOffset.x, vector.y * (float)Screen.height + _pixelOffset.y, MathTools.Clamp((float)Screen.width - vector.x * (float)Screen.width, 0f, float.MaxValue), MathTools.Clamp((float)Screen.height - vector.y * (float)Screen.height, 0f, float.MaxValue)), bvBibYLBiANUAONRpIIYcQFevyCg, ctFkBpfTPhheHkObScVpAfwYOIgYA);
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
			if (vxvEYZXzFlMdBMKqpBAcrivicUBCA == null)
			{
				Logger.LogError("Text component has been deleted.");
				return;
			}
			RectTransform component = vxvEYZXzFlMdBMKqpBAcrivicUBCA.GetComponent<RectTransform>();
			if (component.anchoredPosition != _pixelOffset)
			{
				component.anchoredPosition = _pixelOffset;
			}
			vxvEYZXzFlMdBMKqpBAcrivicUBCA.text = bvBibYLBiANUAONRpIIYcQFevyCg;
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			if (DZmYLnNmFltaHWAnPIiIaEVhGrOy && _useUnityUI != pFXeETfhuqWOmDhSDyIkSDPdTMxF)
			{
				pFXeETfhuqWOmDhSDyIkSDPdTMxF = _useUnityUI;
				if (_useUnityUI)
				{
					RlDtlRcsTiCxnWKqjOZZKnrHhzTn();
				}
				else
				{
					OEPRszlXLjeyNdZwzIMvjLulaRHCA();
				}
			}
		}

		private void RlDtlRcsTiCxnWKqjOZZKnrHhzTn()
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
			vxvEYZXzFlMdBMKqpBAcrivicUBCA = GetComponent<Text>();
			if (!(vxvEYZXzFlMdBMKqpBAcrivicUBCA == null))
			{
				return;
			}
			RectTransform rectTransform = base.gameObject.AddComponent<RectTransform>();
			rectTransform.anchorMax = new Vector2(1f, 1f);
			rectTransform.anchorMin = new Vector2(0f, 0f);
			rectTransform.localPosition = Vector2.zero;
			rectTransform.anchoredPosition = Vector2.zero;
			rectTransform.sizeDelta = Vector3.zero;
			vxvEYZXzFlMdBMKqpBAcrivicUBCA = base.gameObject.AddComponent<Text>();
			vxvEYZXzFlMdBMKqpBAcrivicUBCA.color = Color.white;
			if (_useUnityUI)
			{
				try
				{
					vxvEYZXzFlMdBMKqpBAcrivicUBCA.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
				}
				catch
				{
					try
					{
						vxvEYZXzFlMdBMKqpBAcrivicUBCA.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
					}
					catch
					{
						Logger.LogError("No default font found for GUIText.");
					}
				}
			}
			vxvEYZXzFlMdBMKqpBAcrivicUBCA.fontSize = 13;
			if (sdrHcqczldKzcfdolbsJgnqTyFzSA)
			{
				vxvEYZXzFlMdBMKqpBAcrivicUBCA.alignment = BnaJWiPlojxPvwSqMvddAcqFHCfP;
			}
			else
			{
				BnaJWiPlojxPvwSqMvddAcqFHCfP = vxvEYZXzFlMdBMKqpBAcrivicUBCA.alignment;
			}
			if (zirsjHgAQurekicigFrdRqzNwKNu)
			{
				vxvEYZXzFlMdBMKqpBAcrivicUBCA.font = UyabgbInGPgtNxItpCWipvYLVQEE;
			}
			else
			{
				UyabgbInGPgtNxItpCWipvYLVQEE = vxvEYZXzFlMdBMKqpBAcrivicUBCA.font;
			}
			if (DnoqNEAJhuEMmaABrQBgqCcmQvMI)
			{
				vxvEYZXzFlMdBMKqpBAcrivicUBCA.fontSize = xiuTMayunLuHguJcQnCdmkRJTZBA;
			}
			else
			{
				xiuTMayunLuHguJcQnCdmkRJTZBA = vxvEYZXzFlMdBMKqpBAcrivicUBCA.fontSize;
			}
			if (XlRsEXwmSVjfSNhnccLxhFZXmPsE)
			{
				vxvEYZXzFlMdBMKqpBAcrivicUBCA.fontStyle = djxarEJVwDcIMwmaxNhOQpQGiwToA;
			}
			else
			{
				djxarEJVwDcIMwmaxNhOQpQGiwToA = vxvEYZXzFlMdBMKqpBAcrivicUBCA.fontStyle;
			}
			if (KZmByHtklAbKFFsdpaXFSfYoyzwPA)
			{
				vxvEYZXzFlMdBMKqpBAcrivicUBCA.color = agtehGiccmKZGEZXmXDnUPYeQANRA;
			}
			else
			{
				agtehGiccmKZGEZXmXDnUPYeQANRA = vxvEYZXzFlMdBMKqpBAcrivicUBCA.color;
			}
		}

		private void OEPRszlXLjeyNdZwzIMvjLulaRHCA()
		{
			if (Application.isPlaying)
			{
				if (vxvEYZXzFlMdBMKqpBAcrivicUBCA != null)
				{
					vxvEYZXzFlMdBMKqpBAcrivicUBCA.text = string.Empty;
				}
				vxvEYZXzFlMdBMKqpBAcrivicUBCA = null;
			}
		}

		private void FezdmQUJZxrpJMGFuUKYlonWhLWY()
		{
			ctFkBpfTPhheHkObScVpAfwYOIgYA = new GUIStyle(GUI.skin.label);
			if (sdrHcqczldKzcfdolbsJgnqTyFzSA)
			{
				ctFkBpfTPhheHkObScVpAfwYOIgYA.alignment = BnaJWiPlojxPvwSqMvddAcqFHCfP;
			}
			else
			{
				BnaJWiPlojxPvwSqMvddAcqFHCfP = ctFkBpfTPhheHkObScVpAfwYOIgYA.alignment;
			}
			if (zirsjHgAQurekicigFrdRqzNwKNu)
			{
				ctFkBpfTPhheHkObScVpAfwYOIgYA.font = UyabgbInGPgtNxItpCWipvYLVQEE;
			}
			else
			{
				UyabgbInGPgtNxItpCWipvYLVQEE = ctFkBpfTPhheHkObScVpAfwYOIgYA.font;
			}
			if (DnoqNEAJhuEMmaABrQBgqCcmQvMI)
			{
				ctFkBpfTPhheHkObScVpAfwYOIgYA.fontSize = xiuTMayunLuHguJcQnCdmkRJTZBA;
			}
			else
			{
				xiuTMayunLuHguJcQnCdmkRJTZBA = ctFkBpfTPhheHkObScVpAfwYOIgYA.fontSize;
			}
			if (XlRsEXwmSVjfSNhnccLxhFZXmPsE)
			{
				ctFkBpfTPhheHkObScVpAfwYOIgYA.fontStyle = djxarEJVwDcIMwmaxNhOQpQGiwToA;
			}
			else
			{
				djxarEJVwDcIMwmaxNhOQpQGiwToA = ctFkBpfTPhheHkObScVpAfwYOIgYA.fontStyle;
			}
			if (KZmByHtklAbKFFsdpaXFSfYoyzwPA)
			{
				ctFkBpfTPhheHkObScVpAfwYOIgYA.normal.textColor = agtehGiccmKZGEZXmXDnUPYeQANRA;
			}
			else
			{
				agtehGiccmKZGEZXmXDnUPYeQANRA = ctFkBpfTPhheHkObScVpAfwYOIgYA.normal.textColor;
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
