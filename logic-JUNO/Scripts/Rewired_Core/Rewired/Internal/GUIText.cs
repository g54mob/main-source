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
		private string CfdUVWFOfrULjLkECAoUxVzRELQs;

		private GUIStyle HZlqEzdGSQecobMcpjlhbySzGamTA;

		private TextAnchor sfMOkaDQzUGtSavltmPjHJCeVgftA;

		private TextAlignment veyMZbQfBSEVFdBSHLflOThTrlGw;

		private float FGnAmaMcQMqUpLPEYwNLXmSFKIWw;

		private Font jNMcCrAQskLkkdeXGPygtwNukhCKA;

		private int YEChmMoXtCBsahfWPTXAzTOeGjRjA = -1;

		private FontStyle MwHAMsJbhyOFvvvoYReKyfkfYIPK;

		private Color FHHUCYutfPJCjGKrBzHlMarNwiRe = Color.white;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Vector2 _pixelOffset;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useUnityUI;

		private bool FkNbXaqskWibNyNpGiCTisEsmvtXA;

		private bool tlqvuoLpFaAUInacXgRLmkleRCDw;

		private bool LtOEUmCpWeHofbkfeVJPVzTgjZtIB;

		private bool QEXwHFooVNCzVlphHXVdKJJyvcTp;

		private bool ahCZPQYOUJgERdeZIYosnBAXBwQhA;

		private bool oGnCLRFyfuIftiOgTNIhXabwsCeEb;

		private bool fNEHDNraZdCTijwwYjMTugpNHacf;

		private Text UPVbfHRlYMYfuJmpOHkiaeZNzmDX;

		private bool KtjaTRBtgHpARhUysiYoQVhMEvttA;

		private bool coCYvnVXpKhfsRZamfoKzKpGYJQt;

		public string text
		{
			get
			{
				return CfdUVWFOfrULjLkECAoUxVzRELQs;
			}
			set
			{
				CfdUVWFOfrULjLkECAoUxVzRELQs = value;
			}
		}

		public TextAnchor anchor
		{
			get
			{
				return sfMOkaDQzUGtSavltmPjHJCeVgftA;
			}
			set
			{
				sfMOkaDQzUGtSavltmPjHJCeVgftA = value;
				FkNbXaqskWibNyNpGiCTisEsmvtXA = true;
				if (HZlqEzdGSQecobMcpjlhbySzGamTA != null)
				{
					HZlqEzdGSQecobMcpjlhbySzGamTA.alignment = value;
				}
			}
		}

		public TextAlignment alignment
		{
			get
			{
				return veyMZbQfBSEVFdBSHLflOThTrlGw;
			}
			set
			{
				veyMZbQfBSEVFdBSHLflOThTrlGw = value;
				tlqvuoLpFaAUInacXgRLmkleRCDw = true;
			}
		}

		public float lineSpacing
		{
			get
			{
				return FGnAmaMcQMqUpLPEYwNLXmSFKIWw;
			}
			set
			{
				FGnAmaMcQMqUpLPEYwNLXmSFKIWw = value;
				LtOEUmCpWeHofbkfeVJPVzTgjZtIB = true;
				_ = HZlqEzdGSQecobMcpjlhbySzGamTA;
			}
		}

		public Font font
		{
			get
			{
				return jNMcCrAQskLkkdeXGPygtwNukhCKA;
			}
			set
			{
				QEXwHFooVNCzVlphHXVdKJJyvcTp = true;
				jNMcCrAQskLkkdeXGPygtwNukhCKA = value;
				if (HZlqEzdGSQecobMcpjlhbySzGamTA != null)
				{
					HZlqEzdGSQecobMcpjlhbySzGamTA.font = value;
				}
			}
		}

		public int fontSize
		{
			get
			{
				return YEChmMoXtCBsahfWPTXAzTOeGjRjA;
			}
			set
			{
				YEChmMoXtCBsahfWPTXAzTOeGjRjA = value;
				ahCZPQYOUJgERdeZIYosnBAXBwQhA = true;
				if (HZlqEzdGSQecobMcpjlhbySzGamTA != null)
				{
					HZlqEzdGSQecobMcpjlhbySzGamTA.fontSize = value;
				}
			}
		}

		public FontStyle fontStyle
		{
			get
			{
				return MwHAMsJbhyOFvvvoYReKyfkfYIPK;
			}
			set
			{
				MwHAMsJbhyOFvvvoYReKyfkfYIPK = value;
				oGnCLRFyfuIftiOgTNIhXabwsCeEb = true;
				if (HZlqEzdGSQecobMcpjlhbySzGamTA != null)
				{
					HZlqEzdGSQecobMcpjlhbySzGamTA.fontStyle = value;
				}
			}
		}

		public Color color
		{
			get
			{
				return FHHUCYutfPJCjGKrBzHlMarNwiRe;
			}
			set
			{
				FHHUCYutfPJCjGKrBzHlMarNwiRe = value;
				fNEHDNraZdCTijwwYjMTugpNHacf = true;
				if (HZlqEzdGSQecobMcpjlhbySzGamTA != null)
				{
					HZlqEzdGSQecobMcpjlhbySzGamTA.normal.textColor = value;
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
					KtjaTRBtgHpARhUysiYoQVhMEvttA = value;
					if (value)
					{
						cpbOhDmaYDzPCTbVYbAXHeRuPqXF();
					}
					else
					{
						nTnFztrDYIyYoaTxGuQtkpQWfRZI();
					}
				}
			}
		}

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			coCYvnVXpKhfsRZamfoKzKpGYJQt = true;
		}

		[CustomObfuscation(rename = false)]
		private void Start()
		{
			KtjaTRBtgHpARhUysiYoQVhMEvttA = _useUnityUI;
			if (_useUnityUI)
			{
				cpbOhDmaYDzPCTbVYbAXHeRuPqXF();
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			if (!_useUnityUI)
			{
				if (HZlqEzdGSQecobMcpjlhbySzGamTA == null)
				{
					uUTePUCQKAwnoPACPsoWsgHpnvER();
				}
				if (!string.IsNullOrEmpty(CfdUVWFOfrULjLkECAoUxVzRELQs))
				{
					Vector2 vector = base.transform.localPosition;
					GUI.Label(new Rect(vector.x * (float)Screen.width + _pixelOffset.x, vector.y * (float)Screen.height + _pixelOffset.y, MathTools.Clamp((float)Screen.width - vector.x * (float)Screen.width, 0f, float.MaxValue), MathTools.Clamp((float)Screen.height - vector.y * (float)Screen.height, 0f, float.MaxValue)), CfdUVWFOfrULjLkECAoUxVzRELQs, HZlqEzdGSQecobMcpjlhbySzGamTA);
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
			if (UPVbfHRlYMYfuJmpOHkiaeZNzmDX == null)
			{
				Logger.LogError("Text component has been deleted.");
				return;
			}
			RectTransform component = UPVbfHRlYMYfuJmpOHkiaeZNzmDX.GetComponent<RectTransform>();
			if (component.anchoredPosition != _pixelOffset)
			{
				component.anchoredPosition = _pixelOffset;
			}
			UPVbfHRlYMYfuJmpOHkiaeZNzmDX.text = CfdUVWFOfrULjLkECAoUxVzRELQs;
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			if (coCYvnVXpKhfsRZamfoKzKpGYJQt && _useUnityUI != KtjaTRBtgHpARhUysiYoQVhMEvttA)
			{
				KtjaTRBtgHpARhUysiYoQVhMEvttA = _useUnityUI;
				if (_useUnityUI)
				{
					cpbOhDmaYDzPCTbVYbAXHeRuPqXF();
				}
				else
				{
					nTnFztrDYIyYoaTxGuQtkpQWfRZI();
				}
			}
		}

		private void cpbOhDmaYDzPCTbVYbAXHeRuPqXF()
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
			UPVbfHRlYMYfuJmpOHkiaeZNzmDX = GetComponent<Text>();
			if (!(UPVbfHRlYMYfuJmpOHkiaeZNzmDX == null))
			{
				return;
			}
			RectTransform rectTransform = base.gameObject.AddComponent<RectTransform>();
			rectTransform.anchorMax = new Vector2(1f, 1f);
			rectTransform.anchorMin = new Vector2(0f, 0f);
			rectTransform.localPosition = Vector2.zero;
			rectTransform.anchoredPosition = Vector2.zero;
			rectTransform.sizeDelta = Vector3.zero;
			UPVbfHRlYMYfuJmpOHkiaeZNzmDX = base.gameObject.AddComponent<Text>();
			UPVbfHRlYMYfuJmpOHkiaeZNzmDX.color = Color.white;
			if (_useUnityUI)
			{
				try
				{
					UPVbfHRlYMYfuJmpOHkiaeZNzmDX.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
				}
				catch
				{
					try
					{
						UPVbfHRlYMYfuJmpOHkiaeZNzmDX.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
					}
					catch
					{
						Logger.LogError("No default font found for GUIText.");
					}
				}
			}
			UPVbfHRlYMYfuJmpOHkiaeZNzmDX.fontSize = 13;
			if (FkNbXaqskWibNyNpGiCTisEsmvtXA)
			{
				UPVbfHRlYMYfuJmpOHkiaeZNzmDX.alignment = sfMOkaDQzUGtSavltmPjHJCeVgftA;
			}
			else
			{
				sfMOkaDQzUGtSavltmPjHJCeVgftA = UPVbfHRlYMYfuJmpOHkiaeZNzmDX.alignment;
			}
			if (QEXwHFooVNCzVlphHXVdKJJyvcTp)
			{
				UPVbfHRlYMYfuJmpOHkiaeZNzmDX.font = jNMcCrAQskLkkdeXGPygtwNukhCKA;
			}
			else
			{
				jNMcCrAQskLkkdeXGPygtwNukhCKA = UPVbfHRlYMYfuJmpOHkiaeZNzmDX.font;
			}
			if (ahCZPQYOUJgERdeZIYosnBAXBwQhA)
			{
				UPVbfHRlYMYfuJmpOHkiaeZNzmDX.fontSize = YEChmMoXtCBsahfWPTXAzTOeGjRjA;
			}
			else
			{
				YEChmMoXtCBsahfWPTXAzTOeGjRjA = UPVbfHRlYMYfuJmpOHkiaeZNzmDX.fontSize;
			}
			if (oGnCLRFyfuIftiOgTNIhXabwsCeEb)
			{
				UPVbfHRlYMYfuJmpOHkiaeZNzmDX.fontStyle = MwHAMsJbhyOFvvvoYReKyfkfYIPK;
			}
			else
			{
				MwHAMsJbhyOFvvvoYReKyfkfYIPK = UPVbfHRlYMYfuJmpOHkiaeZNzmDX.fontStyle;
			}
			if (fNEHDNraZdCTijwwYjMTugpNHacf)
			{
				UPVbfHRlYMYfuJmpOHkiaeZNzmDX.color = FHHUCYutfPJCjGKrBzHlMarNwiRe;
			}
			else
			{
				FHHUCYutfPJCjGKrBzHlMarNwiRe = UPVbfHRlYMYfuJmpOHkiaeZNzmDX.color;
			}
		}

		private void nTnFztrDYIyYoaTxGuQtkpQWfRZI()
		{
			if (Application.isPlaying)
			{
				if (UPVbfHRlYMYfuJmpOHkiaeZNzmDX != null)
				{
					UPVbfHRlYMYfuJmpOHkiaeZNzmDX.text = string.Empty;
				}
				UPVbfHRlYMYfuJmpOHkiaeZNzmDX = null;
			}
		}

		private void uUTePUCQKAwnoPACPsoWsgHpnvER()
		{
			HZlqEzdGSQecobMcpjlhbySzGamTA = new GUIStyle(GUI.skin.label);
			if (FkNbXaqskWibNyNpGiCTisEsmvtXA)
			{
				HZlqEzdGSQecobMcpjlhbySzGamTA.alignment = sfMOkaDQzUGtSavltmPjHJCeVgftA;
			}
			else
			{
				sfMOkaDQzUGtSavltmPjHJCeVgftA = HZlqEzdGSQecobMcpjlhbySzGamTA.alignment;
			}
			if (QEXwHFooVNCzVlphHXVdKJJyvcTp)
			{
				HZlqEzdGSQecobMcpjlhbySzGamTA.font = jNMcCrAQskLkkdeXGPygtwNukhCKA;
			}
			else
			{
				jNMcCrAQskLkkdeXGPygtwNukhCKA = HZlqEzdGSQecobMcpjlhbySzGamTA.font;
			}
			if (ahCZPQYOUJgERdeZIYosnBAXBwQhA)
			{
				HZlqEzdGSQecobMcpjlhbySzGamTA.fontSize = YEChmMoXtCBsahfWPTXAzTOeGjRjA;
			}
			else
			{
				YEChmMoXtCBsahfWPTXAzTOeGjRjA = HZlqEzdGSQecobMcpjlhbySzGamTA.fontSize;
			}
			if (oGnCLRFyfuIftiOgTNIhXabwsCeEb)
			{
				HZlqEzdGSQecobMcpjlhbySzGamTA.fontStyle = MwHAMsJbhyOFvvvoYReKyfkfYIPK;
			}
			else
			{
				MwHAMsJbhyOFvvvoYReKyfkfYIPK = HZlqEzdGSQecobMcpjlhbySzGamTA.fontStyle;
			}
			if (fNEHDNraZdCTijwwYjMTugpNHacf)
			{
				HZlqEzdGSQecobMcpjlhbySzGamTA.normal.textColor = FHHUCYutfPJCjGKrBzHlMarNwiRe;
			}
			else
			{
				FHHUCYutfPJCjGKrBzHlMarNwiRe = HZlqEzdGSQecobMcpjlhbySzGamTA.normal.textColor;
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
