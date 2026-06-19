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
		private string EtjTZlnpNEAFbQqySlZEnquzkPVJ;

		private GUIStyle PfnFqEeVcvkrqnoIpKojuUHBcNlFA;

		private TextAnchor agMguPlaZfuaEgVZtUJpNrHMHhmH;

		private TextAlignment bSuDqGobtjUVZiSoFuIxKYevEPJl;

		private float FtrDoXjsatVRjOWgUXWBcFTfqrBhA;

		private Font vtOIxSwVQFlmmtPrSjNwmbCICkDj;

		private int YxAyMnUDDhJdqswwNGEYfUTQfUGu = -1;

		private FontStyle SqVhMbzaHHNNzyPBWkUAoRhJttUT;

		private Color PNFeKbKURgKMxPXcRkmdKWlrpFUX = Color.white;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Vector2 _pixelOffset;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useUnityUI;

		private bool FPHATTeWQjSkPnxRMiBLWcFGOEmXA;

		private bool lRwyjFbqdFRaUaVYZMyDabaAxpEl;

		private bool FtEElDTbgNKvftRPZvKHvRCXPaqR;

		private bool GFRBCoAyjeoQLmgFVWIhYyIONUEi;

		private bool obYVLdsQgsZNNmrlCxTovRLrPQTh;

		private bool iHrBPuYHRHbqtDcMJOPzmVcWHtfq;

		private bool pTGDHePzIASFukqAOLqFoDvhXezn;

		private Text EwZafoEnetsoevWPAVpqiqYfTTAUA;

		private bool IolBTqBAWiZNTVfMwQZeDXuesOuw;

		private bool sMIfHWhTFhorkInImhdGhbamFsXq;

		public string text
		{
			get
			{
				return EtjTZlnpNEAFbQqySlZEnquzkPVJ;
			}
			set
			{
				EtjTZlnpNEAFbQqySlZEnquzkPVJ = value;
			}
		}

		public TextAnchor anchor
		{
			get
			{
				return agMguPlaZfuaEgVZtUJpNrHMHhmH;
			}
			set
			{
				agMguPlaZfuaEgVZtUJpNrHMHhmH = value;
				FPHATTeWQjSkPnxRMiBLWcFGOEmXA = true;
				if (PfnFqEeVcvkrqnoIpKojuUHBcNlFA != null)
				{
					PfnFqEeVcvkrqnoIpKojuUHBcNlFA.alignment = value;
				}
			}
		}

		public TextAlignment alignment
		{
			get
			{
				return bSuDqGobtjUVZiSoFuIxKYevEPJl;
			}
			set
			{
				bSuDqGobtjUVZiSoFuIxKYevEPJl = value;
				lRwyjFbqdFRaUaVYZMyDabaAxpEl = true;
			}
		}

		public float lineSpacing
		{
			get
			{
				return FtrDoXjsatVRjOWgUXWBcFTfqrBhA;
			}
			set
			{
				FtrDoXjsatVRjOWgUXWBcFTfqrBhA = value;
				FtEElDTbgNKvftRPZvKHvRCXPaqR = true;
				_ = PfnFqEeVcvkrqnoIpKojuUHBcNlFA;
			}
		}

		public Font font
		{
			get
			{
				return vtOIxSwVQFlmmtPrSjNwmbCICkDj;
			}
			set
			{
				GFRBCoAyjeoQLmgFVWIhYyIONUEi = true;
				vtOIxSwVQFlmmtPrSjNwmbCICkDj = value;
				if (PfnFqEeVcvkrqnoIpKojuUHBcNlFA != null)
				{
					PfnFqEeVcvkrqnoIpKojuUHBcNlFA.font = value;
				}
			}
		}

		public int fontSize
		{
			get
			{
				return YxAyMnUDDhJdqswwNGEYfUTQfUGu;
			}
			set
			{
				YxAyMnUDDhJdqswwNGEYfUTQfUGu = value;
				obYVLdsQgsZNNmrlCxTovRLrPQTh = true;
				if (PfnFqEeVcvkrqnoIpKojuUHBcNlFA != null)
				{
					PfnFqEeVcvkrqnoIpKojuUHBcNlFA.fontSize = value;
				}
			}
		}

		public FontStyle fontStyle
		{
			get
			{
				return SqVhMbzaHHNNzyPBWkUAoRhJttUT;
			}
			set
			{
				SqVhMbzaHHNNzyPBWkUAoRhJttUT = value;
				iHrBPuYHRHbqtDcMJOPzmVcWHtfq = true;
				if (PfnFqEeVcvkrqnoIpKojuUHBcNlFA != null)
				{
					PfnFqEeVcvkrqnoIpKojuUHBcNlFA.fontStyle = value;
				}
			}
		}

		public Color color
		{
			get
			{
				return PNFeKbKURgKMxPXcRkmdKWlrpFUX;
			}
			set
			{
				PNFeKbKURgKMxPXcRkmdKWlrpFUX = value;
				pTGDHePzIASFukqAOLqFoDvhXezn = true;
				if (PfnFqEeVcvkrqnoIpKojuUHBcNlFA != null)
				{
					PfnFqEeVcvkrqnoIpKojuUHBcNlFA.normal.textColor = value;
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
					IolBTqBAWiZNTVfMwQZeDXuesOuw = value;
					if (value)
					{
						sHpOIwKeekCwYBATAwmJaNYAowQDA();
					}
					else
					{
						jtxxRMTJqrBncadJCNrrjyNwQMOWA();
					}
				}
			}
		}

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			sMIfHWhTFhorkInImhdGhbamFsXq = true;
		}

		[CustomObfuscation(rename = false)]
		private void Start()
		{
			IolBTqBAWiZNTVfMwQZeDXuesOuw = _useUnityUI;
			if (_useUnityUI)
			{
				sHpOIwKeekCwYBATAwmJaNYAowQDA();
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			if (!_useUnityUI)
			{
				if (PfnFqEeVcvkrqnoIpKojuUHBcNlFA == null)
				{
					mpPDhtsuXbsmCAgRXjUssCoLYTNB();
				}
				if (!string.IsNullOrEmpty(EtjTZlnpNEAFbQqySlZEnquzkPVJ))
				{
					Vector2 vector = base.transform.localPosition;
					GUI.Label(new Rect(vector.x * (float)Screen.width + _pixelOffset.x, vector.y * (float)Screen.height + _pixelOffset.y, MathTools.Clamp((float)Screen.width - vector.x * (float)Screen.width, 0f, float.MaxValue), MathTools.Clamp((float)Screen.height - vector.y * (float)Screen.height, 0f, float.MaxValue)), EtjTZlnpNEAFbQqySlZEnquzkPVJ, PfnFqEeVcvkrqnoIpKojuUHBcNlFA);
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
			if (EwZafoEnetsoevWPAVpqiqYfTTAUA == null)
			{
				Logger.LogError("Text component has been deleted.");
				return;
			}
			RectTransform component = EwZafoEnetsoevWPAVpqiqYfTTAUA.GetComponent<RectTransform>();
			if (component.anchoredPosition != _pixelOffset)
			{
				component.anchoredPosition = _pixelOffset;
			}
			EwZafoEnetsoevWPAVpqiqYfTTAUA.text = EtjTZlnpNEAFbQqySlZEnquzkPVJ;
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			if (sMIfHWhTFhorkInImhdGhbamFsXq && _useUnityUI != IolBTqBAWiZNTVfMwQZeDXuesOuw)
			{
				IolBTqBAWiZNTVfMwQZeDXuesOuw = _useUnityUI;
				if (_useUnityUI)
				{
					sHpOIwKeekCwYBATAwmJaNYAowQDA();
				}
				else
				{
					jtxxRMTJqrBncadJCNrrjyNwQMOWA();
				}
			}
		}

		private void sHpOIwKeekCwYBATAwmJaNYAowQDA()
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
			EwZafoEnetsoevWPAVpqiqYfTTAUA = GetComponent<Text>();
			if (!(EwZafoEnetsoevWPAVpqiqYfTTAUA == null))
			{
				return;
			}
			RectTransform rectTransform = base.gameObject.AddComponent<RectTransform>();
			rectTransform.anchorMax = new Vector2(1f, 1f);
			rectTransform.anchorMin = new Vector2(0f, 0f);
			rectTransform.localPosition = Vector2.zero;
			rectTransform.anchoredPosition = Vector2.zero;
			rectTransform.sizeDelta = Vector3.zero;
			EwZafoEnetsoevWPAVpqiqYfTTAUA = base.gameObject.AddComponent<Text>();
			EwZafoEnetsoevWPAVpqiqYfTTAUA.color = Color.white;
			if (_useUnityUI)
			{
				try
				{
					EwZafoEnetsoevWPAVpqiqYfTTAUA.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
				}
				catch
				{
					try
					{
						EwZafoEnetsoevWPAVpqiqYfTTAUA.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
					}
					catch
					{
						Logger.LogError("No default font found for GUIText.");
					}
				}
			}
			EwZafoEnetsoevWPAVpqiqYfTTAUA.fontSize = 13;
			if (FPHATTeWQjSkPnxRMiBLWcFGOEmXA)
			{
				EwZafoEnetsoevWPAVpqiqYfTTAUA.alignment = agMguPlaZfuaEgVZtUJpNrHMHhmH;
			}
			else
			{
				agMguPlaZfuaEgVZtUJpNrHMHhmH = EwZafoEnetsoevWPAVpqiqYfTTAUA.alignment;
			}
			if (GFRBCoAyjeoQLmgFVWIhYyIONUEi)
			{
				EwZafoEnetsoevWPAVpqiqYfTTAUA.font = vtOIxSwVQFlmmtPrSjNwmbCICkDj;
			}
			else
			{
				vtOIxSwVQFlmmtPrSjNwmbCICkDj = EwZafoEnetsoevWPAVpqiqYfTTAUA.font;
			}
			if (obYVLdsQgsZNNmrlCxTovRLrPQTh)
			{
				EwZafoEnetsoevWPAVpqiqYfTTAUA.fontSize = YxAyMnUDDhJdqswwNGEYfUTQfUGu;
			}
			else
			{
				YxAyMnUDDhJdqswwNGEYfUTQfUGu = EwZafoEnetsoevWPAVpqiqYfTTAUA.fontSize;
			}
			if (iHrBPuYHRHbqtDcMJOPzmVcWHtfq)
			{
				EwZafoEnetsoevWPAVpqiqYfTTAUA.fontStyle = SqVhMbzaHHNNzyPBWkUAoRhJttUT;
			}
			else
			{
				SqVhMbzaHHNNzyPBWkUAoRhJttUT = EwZafoEnetsoevWPAVpqiqYfTTAUA.fontStyle;
			}
			if (pTGDHePzIASFukqAOLqFoDvhXezn)
			{
				EwZafoEnetsoevWPAVpqiqYfTTAUA.color = PNFeKbKURgKMxPXcRkmdKWlrpFUX;
			}
			else
			{
				PNFeKbKURgKMxPXcRkmdKWlrpFUX = EwZafoEnetsoevWPAVpqiqYfTTAUA.color;
			}
		}

		private void jtxxRMTJqrBncadJCNrrjyNwQMOWA()
		{
			if (Application.isPlaying)
			{
				if (EwZafoEnetsoevWPAVpqiqYfTTAUA != null)
				{
					EwZafoEnetsoevWPAVpqiqYfTTAUA.text = string.Empty;
				}
				EwZafoEnetsoevWPAVpqiqYfTTAUA = null;
			}
		}

		private void mpPDhtsuXbsmCAgRXjUssCoLYTNB()
		{
			PfnFqEeVcvkrqnoIpKojuUHBcNlFA = new GUIStyle(GUI.skin.label);
			if (FPHATTeWQjSkPnxRMiBLWcFGOEmXA)
			{
				PfnFqEeVcvkrqnoIpKojuUHBcNlFA.alignment = agMguPlaZfuaEgVZtUJpNrHMHhmH;
			}
			else
			{
				agMguPlaZfuaEgVZtUJpNrHMHhmH = PfnFqEeVcvkrqnoIpKojuUHBcNlFA.alignment;
			}
			if (GFRBCoAyjeoQLmgFVWIhYyIONUEi)
			{
				PfnFqEeVcvkrqnoIpKojuUHBcNlFA.font = vtOIxSwVQFlmmtPrSjNwmbCICkDj;
			}
			else
			{
				vtOIxSwVQFlmmtPrSjNwmbCICkDj = PfnFqEeVcvkrqnoIpKojuUHBcNlFA.font;
			}
			if (obYVLdsQgsZNNmrlCxTovRLrPQTh)
			{
				PfnFqEeVcvkrqnoIpKojuUHBcNlFA.fontSize = YxAyMnUDDhJdqswwNGEYfUTQfUGu;
			}
			else
			{
				YxAyMnUDDhJdqswwNGEYfUTQfUGu = PfnFqEeVcvkrqnoIpKojuUHBcNlFA.fontSize;
			}
			if (iHrBPuYHRHbqtDcMJOPzmVcWHtfq)
			{
				PfnFqEeVcvkrqnoIpKojuUHBcNlFA.fontStyle = SqVhMbzaHHNNzyPBWkUAoRhJttUT;
			}
			else
			{
				SqVhMbzaHHNNzyPBWkUAoRhJttUT = PfnFqEeVcvkrqnoIpKojuUHBcNlFA.fontStyle;
			}
			if (pTGDHePzIASFukqAOLqFoDvhXezn)
			{
				PfnFqEeVcvkrqnoIpKojuUHBcNlFA.normal.textColor = PNFeKbKURgKMxPXcRkmdKWlrpFUX;
			}
			else
			{
				PNFeKbKURgKMxPXcRkmdKWlrpFUX = PfnFqEeVcvkrqnoIpKojuUHBcNlFA.normal.textColor;
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
