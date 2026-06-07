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
		private string IUvJjsVjeOMrXbERVaThosYUvTBe;

		private GUIStyle JgrFkHfiAhznYBvmcbhYnRTupQvR;

		private TextAnchor gjMqYSVarxuZaHAxqVkAQpLfMxig;

		private TextAlignment nvsZXDIbRxCGtVYQWbiGXIiUkTJR;

		private float DodeqOKMCnMNRpoMNaZaMRTSEqJV;

		private Font tEtWFgWeTezMtODRikDWjWzVPFgA;

		private int USGcbwstplboAZMNQBXtcBwtRROD = -1;

		private FontStyle UvLEQoBVdJCTLBJxHSTbhjxeymAuA;

		private Color VSLDSsdujaRQDMeSCffGxJhIzYYsA = Color.white;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Vector2 _pixelOffset;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useUnityUI;

		private bool DRViNCmlwnysbAwzNOWezyVrFEml;

		private bool lougUETHhLFSkDkpSRYelsNbqiOf;

		private bool FTSWQmdIGPniVYxoWNAiyKpqhaxc;

		private bool KhDZNrcTmcshpJtCSNMWPGdhYxME;

		private bool wWCZLaIEIcFbrHNNFaOBmOVGOtPF;

		private bool gzMRpauzZbqBgmqYdCKfSwpFqlp;

		private bool lzCDZrGlyOJXUUXoTsvcqttOFzfKA;

		private Text UWXHzjHDQfgmKrRxBkyDhJOKmUQu;

		private bool EHdZnntqZyHzUukOfIRPImaVDggc;

		private bool gqObBDVJhbgHSntkrybfgeeZCrTO;

		public string text
		{
			get
			{
				return IUvJjsVjeOMrXbERVaThosYUvTBe;
			}
			set
			{
				IUvJjsVjeOMrXbERVaThosYUvTBe = value;
			}
		}

		public TextAnchor anchor
		{
			get
			{
				return gjMqYSVarxuZaHAxqVkAQpLfMxig;
			}
			set
			{
				gjMqYSVarxuZaHAxqVkAQpLfMxig = value;
				DRViNCmlwnysbAwzNOWezyVrFEml = true;
				if (JgrFkHfiAhznYBvmcbhYnRTupQvR != null)
				{
					JgrFkHfiAhznYBvmcbhYnRTupQvR.alignment = value;
				}
			}
		}

		public TextAlignment alignment
		{
			get
			{
				return nvsZXDIbRxCGtVYQWbiGXIiUkTJR;
			}
			set
			{
				nvsZXDIbRxCGtVYQWbiGXIiUkTJR = value;
				lougUETHhLFSkDkpSRYelsNbqiOf = true;
			}
		}

		public float lineSpacing
		{
			get
			{
				return DodeqOKMCnMNRpoMNaZaMRTSEqJV;
			}
			set
			{
				DodeqOKMCnMNRpoMNaZaMRTSEqJV = value;
				FTSWQmdIGPniVYxoWNAiyKpqhaxc = true;
				_ = JgrFkHfiAhznYBvmcbhYnRTupQvR;
			}
		}

		public Font font
		{
			get
			{
				return tEtWFgWeTezMtODRikDWjWzVPFgA;
			}
			set
			{
				KhDZNrcTmcshpJtCSNMWPGdhYxME = true;
				tEtWFgWeTezMtODRikDWjWzVPFgA = value;
				if (JgrFkHfiAhznYBvmcbhYnRTupQvR != null)
				{
					JgrFkHfiAhznYBvmcbhYnRTupQvR.font = value;
				}
			}
		}

		public int fontSize
		{
			get
			{
				return USGcbwstplboAZMNQBXtcBwtRROD;
			}
			set
			{
				USGcbwstplboAZMNQBXtcBwtRROD = value;
				wWCZLaIEIcFbrHNNFaOBmOVGOtPF = true;
				if (JgrFkHfiAhznYBvmcbhYnRTupQvR != null)
				{
					JgrFkHfiAhznYBvmcbhYnRTupQvR.fontSize = value;
				}
			}
		}

		public FontStyle fontStyle
		{
			get
			{
				return UvLEQoBVdJCTLBJxHSTbhjxeymAuA;
			}
			set
			{
				UvLEQoBVdJCTLBJxHSTbhjxeymAuA = value;
				gzMRpauzZbqBgmqYdCKfSwpFqlp = true;
				if (JgrFkHfiAhznYBvmcbhYnRTupQvR != null)
				{
					JgrFkHfiAhznYBvmcbhYnRTupQvR.fontStyle = value;
				}
			}
		}

		public Color color
		{
			get
			{
				return VSLDSsdujaRQDMeSCffGxJhIzYYsA;
			}
			set
			{
				VSLDSsdujaRQDMeSCffGxJhIzYYsA = value;
				lzCDZrGlyOJXUUXoTsvcqttOFzfKA = true;
				if (JgrFkHfiAhznYBvmcbhYnRTupQvR != null)
				{
					JgrFkHfiAhznYBvmcbhYnRTupQvR.normal.textColor = value;
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
					EHdZnntqZyHzUukOfIRPImaVDggc = value;
					if (value)
					{
						iMrxUteeCqEgqajnBVfwQGAhAtGRA();
					}
					else
					{
						jPnORVbLKlPtWCZrLdcApbDPINEJA();
					}
				}
			}
		}

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			gqObBDVJhbgHSntkrybfgeeZCrTO = true;
		}

		[CustomObfuscation(rename = false)]
		private void Start()
		{
			EHdZnntqZyHzUukOfIRPImaVDggc = _useUnityUI;
			if (_useUnityUI)
			{
				iMrxUteeCqEgqajnBVfwQGAhAtGRA();
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			if (!_useUnityUI)
			{
				if (JgrFkHfiAhznYBvmcbhYnRTupQvR == null)
				{
					onXaPuOTCnDcYnGIQGyxFdSsZHTiA();
				}
				if (!string.IsNullOrEmpty(IUvJjsVjeOMrXbERVaThosYUvTBe))
				{
					Vector2 vector = base.transform.localPosition;
					GUI.Label(new Rect(vector.x * (float)Screen.width + _pixelOffset.x, vector.y * (float)Screen.height + _pixelOffset.y, MathTools.Clamp((float)Screen.width - vector.x * (float)Screen.width, 0f, float.MaxValue), MathTools.Clamp((float)Screen.height - vector.y * (float)Screen.height, 0f, float.MaxValue)), IUvJjsVjeOMrXbERVaThosYUvTBe, JgrFkHfiAhznYBvmcbhYnRTupQvR);
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
			if (UWXHzjHDQfgmKrRxBkyDhJOKmUQu == null)
			{
				Logger.LogError("Text component has been deleted.");
				return;
			}
			RectTransform component = UWXHzjHDQfgmKrRxBkyDhJOKmUQu.GetComponent<RectTransform>();
			if (component.anchoredPosition != _pixelOffset)
			{
				component.anchoredPosition = _pixelOffset;
			}
			UWXHzjHDQfgmKrRxBkyDhJOKmUQu.text = IUvJjsVjeOMrXbERVaThosYUvTBe;
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			if (gqObBDVJhbgHSntkrybfgeeZCrTO && _useUnityUI != EHdZnntqZyHzUukOfIRPImaVDggc)
			{
				EHdZnntqZyHzUukOfIRPImaVDggc = _useUnityUI;
				if (_useUnityUI)
				{
					iMrxUteeCqEgqajnBVfwQGAhAtGRA();
				}
				else
				{
					jPnORVbLKlPtWCZrLdcApbDPINEJA();
				}
			}
		}

		private void iMrxUteeCqEgqajnBVfwQGAhAtGRA()
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
			UWXHzjHDQfgmKrRxBkyDhJOKmUQu = GetComponent<Text>();
			if (!(UWXHzjHDQfgmKrRxBkyDhJOKmUQu == null))
			{
				return;
			}
			RectTransform rectTransform = base.gameObject.AddComponent<RectTransform>();
			rectTransform.anchorMax = new Vector2(1f, 1f);
			rectTransform.anchorMin = new Vector2(0f, 0f);
			rectTransform.localPosition = Vector2.zero;
			rectTransform.anchoredPosition = Vector2.zero;
			rectTransform.sizeDelta = Vector3.zero;
			UWXHzjHDQfgmKrRxBkyDhJOKmUQu = base.gameObject.AddComponent<Text>();
			UWXHzjHDQfgmKrRxBkyDhJOKmUQu.color = Color.white;
			if (_useUnityUI)
			{
				try
				{
					UWXHzjHDQfgmKrRxBkyDhJOKmUQu.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
				}
				catch
				{
					try
					{
						UWXHzjHDQfgmKrRxBkyDhJOKmUQu.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
					}
					catch
					{
						Logger.LogError("No default font found for GUIText.");
					}
				}
			}
			UWXHzjHDQfgmKrRxBkyDhJOKmUQu.fontSize = 13;
			if (DRViNCmlwnysbAwzNOWezyVrFEml)
			{
				UWXHzjHDQfgmKrRxBkyDhJOKmUQu.alignment = gjMqYSVarxuZaHAxqVkAQpLfMxig;
			}
			else
			{
				gjMqYSVarxuZaHAxqVkAQpLfMxig = UWXHzjHDQfgmKrRxBkyDhJOKmUQu.alignment;
			}
			if (KhDZNrcTmcshpJtCSNMWPGdhYxME)
			{
				UWXHzjHDQfgmKrRxBkyDhJOKmUQu.font = tEtWFgWeTezMtODRikDWjWzVPFgA;
			}
			else
			{
				tEtWFgWeTezMtODRikDWjWzVPFgA = UWXHzjHDQfgmKrRxBkyDhJOKmUQu.font;
			}
			if (wWCZLaIEIcFbrHNNFaOBmOVGOtPF)
			{
				UWXHzjHDQfgmKrRxBkyDhJOKmUQu.fontSize = USGcbwstplboAZMNQBXtcBwtRROD;
			}
			else
			{
				USGcbwstplboAZMNQBXtcBwtRROD = UWXHzjHDQfgmKrRxBkyDhJOKmUQu.fontSize;
			}
			if (gzMRpauzZbqBgmqYdCKfSwpFqlp)
			{
				UWXHzjHDQfgmKrRxBkyDhJOKmUQu.fontStyle = UvLEQoBVdJCTLBJxHSTbhjxeymAuA;
			}
			else
			{
				UvLEQoBVdJCTLBJxHSTbhjxeymAuA = UWXHzjHDQfgmKrRxBkyDhJOKmUQu.fontStyle;
			}
			if (lzCDZrGlyOJXUUXoTsvcqttOFzfKA)
			{
				UWXHzjHDQfgmKrRxBkyDhJOKmUQu.color = VSLDSsdujaRQDMeSCffGxJhIzYYsA;
			}
			else
			{
				VSLDSsdujaRQDMeSCffGxJhIzYYsA = UWXHzjHDQfgmKrRxBkyDhJOKmUQu.color;
			}
		}

		private void jPnORVbLKlPtWCZrLdcApbDPINEJA()
		{
			if (Application.isPlaying)
			{
				if (UWXHzjHDQfgmKrRxBkyDhJOKmUQu != null)
				{
					UWXHzjHDQfgmKrRxBkyDhJOKmUQu.text = string.Empty;
				}
				UWXHzjHDQfgmKrRxBkyDhJOKmUQu = null;
			}
		}

		private void onXaPuOTCnDcYnGIQGyxFdSsZHTiA()
		{
			JgrFkHfiAhznYBvmcbhYnRTupQvR = new GUIStyle(GUI.skin.label);
			if (DRViNCmlwnysbAwzNOWezyVrFEml)
			{
				JgrFkHfiAhznYBvmcbhYnRTupQvR.alignment = gjMqYSVarxuZaHAxqVkAQpLfMxig;
			}
			else
			{
				gjMqYSVarxuZaHAxqVkAQpLfMxig = JgrFkHfiAhznYBvmcbhYnRTupQvR.alignment;
			}
			if (KhDZNrcTmcshpJtCSNMWPGdhYxME)
			{
				JgrFkHfiAhznYBvmcbhYnRTupQvR.font = tEtWFgWeTezMtODRikDWjWzVPFgA;
			}
			else
			{
				tEtWFgWeTezMtODRikDWjWzVPFgA = JgrFkHfiAhznYBvmcbhYnRTupQvR.font;
			}
			if (wWCZLaIEIcFbrHNNFaOBmOVGOtPF)
			{
				JgrFkHfiAhznYBvmcbhYnRTupQvR.fontSize = USGcbwstplboAZMNQBXtcBwtRROD;
			}
			else
			{
				USGcbwstplboAZMNQBXtcBwtRROD = JgrFkHfiAhznYBvmcbhYnRTupQvR.fontSize;
			}
			if (gzMRpauzZbqBgmqYdCKfSwpFqlp)
			{
				JgrFkHfiAhznYBvmcbhYnRTupQvR.fontStyle = UvLEQoBVdJCTLBJxHSTbhjxeymAuA;
			}
			else
			{
				UvLEQoBVdJCTLBJxHSTbhjxeymAuA = JgrFkHfiAhznYBvmcbhYnRTupQvR.fontStyle;
			}
			if (lzCDZrGlyOJXUUXoTsvcqttOFzfKA)
			{
				JgrFkHfiAhznYBvmcbhYnRTupQvR.normal.textColor = VSLDSsdujaRQDMeSCffGxJhIzYYsA;
			}
			else
			{
				VSLDSsdujaRQDMeSCffGxJhIzYYsA = JgrFkHfiAhznYBvmcbhYnRTupQvR.normal.textColor;
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
