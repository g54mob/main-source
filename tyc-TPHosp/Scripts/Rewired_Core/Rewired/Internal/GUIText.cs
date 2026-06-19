using System.ComponentModel;
using Rewired.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.Internal
{
	[AddComponentMenu("")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public class GUIText : MonoBehaviour
	{
		private string WbkHiIJqkveOHPoqnFzmQqhtEnv;

		private GUIStyle lHIrODipuIAyOBOuSQnbHibFzut;

		private TextAnchor LLXBCwKhgNCBqvSIBeEwkxcwCeX;

		private TextAlignment KVWzRuVJACEXBuaEtgkjivWnjVYz;

		private float AuappxRRhagqswgeARgYcyWNrLb;

		private Font GnGWxyQjDatdCniWCEZIAXkwuIA;

		private int kgXMRjngYjZQBAmUxrJTimWiVjp = -1;

		private FontStyle erxqUBMWqgPlwYyArEADyJFzgdA;

		private Color uQLoRyWjTBxHBIaWbEtCCwJVqiX = Color.white;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Vector2 _pixelOffset;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _useUnityUI;

		private bool qlWWAISCkfaRtwMyHznWGLHlhDj;

		private bool JkmZkJfIhBcvEUnpLfoWApcocJU;

		private bool PABNJWVNAzBgxnjpupdPlIFcuOW;

		private bool dAxhWGNIxAdwJcdjSUDSPbIlDAid;

		private bool hAnUuiyeOdsILoqYGyowOZylMDz;

		private bool tCBPAvoYzZHQvNIZTJraxKBjwiR;

		private bool fpFYmYhvwgaLAWplPmekypDCGn;

		private Text VYzxGfkwAkfDNnMiEJFRKoaCWSP;

		private bool ZTauwPrBJAWKRehssZmoyGPjEac;

		private bool yNYshUXYQBJZOZGhQOqqytqJOcP;

		public string text
		{
			get
			{
				return WbkHiIJqkveOHPoqnFzmQqhtEnv;
			}
			set
			{
				WbkHiIJqkveOHPoqnFzmQqhtEnv = value;
			}
		}

		public TextAnchor anchor
		{
			get
			{
				return LLXBCwKhgNCBqvSIBeEwkxcwCeX;
			}
			set
			{
				LLXBCwKhgNCBqvSIBeEwkxcwCeX = value;
				qlWWAISCkfaRtwMyHznWGLHlhDj = true;
				if (lHIrODipuIAyOBOuSQnbHibFzut != null)
				{
					lHIrODipuIAyOBOuSQnbHibFzut.alignment = value;
				}
			}
		}

		public TextAlignment alignment
		{
			get
			{
				return KVWzRuVJACEXBuaEtgkjivWnjVYz;
			}
			set
			{
				KVWzRuVJACEXBuaEtgkjivWnjVYz = value;
				JkmZkJfIhBcvEUnpLfoWApcocJU = true;
			}
		}

		public float lineSpacing
		{
			get
			{
				return AuappxRRhagqswgeARgYcyWNrLb;
			}
			set
			{
				AuappxRRhagqswgeARgYcyWNrLb = value;
				PABNJWVNAzBgxnjpupdPlIFcuOW = true;
				_ = lHIrODipuIAyOBOuSQnbHibFzut;
			}
		}

		public Font font
		{
			get
			{
				return GnGWxyQjDatdCniWCEZIAXkwuIA;
			}
			set
			{
				dAxhWGNIxAdwJcdjSUDSPbIlDAid = true;
				GnGWxyQjDatdCniWCEZIAXkwuIA = value;
				if (lHIrODipuIAyOBOuSQnbHibFzut != null)
				{
					lHIrODipuIAyOBOuSQnbHibFzut.font = value;
				}
			}
		}

		public int fontSize
		{
			get
			{
				return kgXMRjngYjZQBAmUxrJTimWiVjp;
			}
			set
			{
				kgXMRjngYjZQBAmUxrJTimWiVjp = value;
				hAnUuiyeOdsILoqYGyowOZylMDz = true;
				if (lHIrODipuIAyOBOuSQnbHibFzut != null)
				{
					lHIrODipuIAyOBOuSQnbHibFzut.fontSize = value;
				}
			}
		}

		public FontStyle fontStyle
		{
			get
			{
				return erxqUBMWqgPlwYyArEADyJFzgdA;
			}
			set
			{
				erxqUBMWqgPlwYyArEADyJFzgdA = value;
				tCBPAvoYzZHQvNIZTJraxKBjwiR = true;
				if (lHIrODipuIAyOBOuSQnbHibFzut != null)
				{
					lHIrODipuIAyOBOuSQnbHibFzut.fontStyle = value;
				}
			}
		}

		public Color color
		{
			get
			{
				return uQLoRyWjTBxHBIaWbEtCCwJVqiX;
			}
			set
			{
				uQLoRyWjTBxHBIaWbEtCCwJVqiX = value;
				fpFYmYhvwgaLAWplPmekypDCGn = true;
				if (lHIrODipuIAyOBOuSQnbHibFzut != null)
				{
					lHIrODipuIAyOBOuSQnbHibFzut.normal.textColor = value;
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
					ZTauwPrBJAWKRehssZmoyGPjEac = value;
					if (value)
					{
						aYSmArPVCySORCuiZMTjJiMMBYKF();
					}
					else
					{
						jucOBTNcliWGPvVoCpKQNyFMQnd();
					}
				}
			}
		}

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			yNYshUXYQBJZOZGhQOqqytqJOcP = true;
		}

		[CustomObfuscation(rename = false)]
		private void Start()
		{
			ZTauwPrBJAWKRehssZmoyGPjEac = _useUnityUI;
			if (_useUnityUI)
			{
				aYSmArPVCySORCuiZMTjJiMMBYKF();
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			if (!_useUnityUI)
			{
				if (lHIrODipuIAyOBOuSQnbHibFzut == null)
				{
					VrzSxkWOCtrBWeyavAOTWOarDVQ();
				}
				if (!string.IsNullOrEmpty(WbkHiIJqkveOHPoqnFzmQqhtEnv))
				{
					Vector2 vector = base.transform.localPosition;
					Rect position = new Rect(vector.x * (float)Screen.width + _pixelOffset.x, vector.y * (float)Screen.height + _pixelOffset.y, MathTools.Clamp((float)Screen.width - vector.x * (float)Screen.width, 0f, float.MaxValue), MathTools.Clamp((float)Screen.height - vector.y * (float)Screen.height, 0f, float.MaxValue));
					GUI.Label(position, WbkHiIJqkveOHPoqnFzmQqhtEnv, lHIrODipuIAyOBOuSQnbHibFzut);
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
			if (VYzxGfkwAkfDNnMiEJFRKoaCWSP == null)
			{
				Logger.LogError("Text component has been deleted.");
				return;
			}
			RectTransform component = VYzxGfkwAkfDNnMiEJFRKoaCWSP.GetComponent<RectTransform>();
			if (component.anchoredPosition != _pixelOffset)
			{
				component.anchoredPosition = _pixelOffset;
			}
			VYzxGfkwAkfDNnMiEJFRKoaCWSP.text = WbkHiIJqkveOHPoqnFzmQqhtEnv;
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			if (yNYshUXYQBJZOZGhQOqqytqJOcP && _useUnityUI != ZTauwPrBJAWKRehssZmoyGPjEac)
			{
				ZTauwPrBJAWKRehssZmoyGPjEac = _useUnityUI;
				if (_useUnityUI)
				{
					aYSmArPVCySORCuiZMTjJiMMBYKF();
				}
				else
				{
					jucOBTNcliWGPvVoCpKQNyFMQnd();
				}
			}
		}

		private void aYSmArPVCySORCuiZMTjJiMMBYKF()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			Canvas componentInSelfOrParents = UnityTools.GetComponentInSelfOrParents<Canvas>(base.transform);
			if (componentInSelfOrParents == null)
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
				componentInSelfOrParents = gameObject.AddComponent<Canvas>();
				componentInSelfOrParents.renderMode = RenderMode.ScreenSpaceOverlay;
				if (!(gameObject.GetComponent<CanvasScaler>() != null))
				{
					gameObject.AddComponent<CanvasScaler>();
				}
				else
				{
					gameObject.GetComponent<CanvasScaler>();
				}
			}
			VYzxGfkwAkfDNnMiEJFRKoaCWSP = GetComponent<Text>();
			if (VYzxGfkwAkfDNnMiEJFRKoaCWSP == null)
			{
				RectTransform rectTransform = base.gameObject.AddComponent<RectTransform>();
				rectTransform.anchorMax = new Vector2(1f, 1f);
				rectTransform.anchorMin = new Vector2(0f, 0f);
				rectTransform.localPosition = Vector2.zero;
				rectTransform.anchoredPosition = Vector2.zero;
				rectTransform.sizeDelta = Vector3.zero;
				VYzxGfkwAkfDNnMiEJFRKoaCWSP = base.gameObject.AddComponent<Text>();
				VYzxGfkwAkfDNnMiEJFRKoaCWSP.color = Color.white;
				VYzxGfkwAkfDNnMiEJFRKoaCWSP.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
				VYzxGfkwAkfDNnMiEJFRKoaCWSP.fontSize = 13;
				if (qlWWAISCkfaRtwMyHznWGLHlhDj)
				{
					VYzxGfkwAkfDNnMiEJFRKoaCWSP.alignment = LLXBCwKhgNCBqvSIBeEwkxcwCeX;
				}
				else
				{
					LLXBCwKhgNCBqvSIBeEwkxcwCeX = VYzxGfkwAkfDNnMiEJFRKoaCWSP.alignment;
				}
				if (dAxhWGNIxAdwJcdjSUDSPbIlDAid)
				{
					VYzxGfkwAkfDNnMiEJFRKoaCWSP.font = GnGWxyQjDatdCniWCEZIAXkwuIA;
				}
				else
				{
					GnGWxyQjDatdCniWCEZIAXkwuIA = VYzxGfkwAkfDNnMiEJFRKoaCWSP.font;
				}
				if (hAnUuiyeOdsILoqYGyowOZylMDz)
				{
					VYzxGfkwAkfDNnMiEJFRKoaCWSP.fontSize = kgXMRjngYjZQBAmUxrJTimWiVjp;
				}
				else
				{
					kgXMRjngYjZQBAmUxrJTimWiVjp = VYzxGfkwAkfDNnMiEJFRKoaCWSP.fontSize;
				}
				if (tCBPAvoYzZHQvNIZTJraxKBjwiR)
				{
					VYzxGfkwAkfDNnMiEJFRKoaCWSP.fontStyle = erxqUBMWqgPlwYyArEADyJFzgdA;
				}
				else
				{
					erxqUBMWqgPlwYyArEADyJFzgdA = VYzxGfkwAkfDNnMiEJFRKoaCWSP.fontStyle;
				}
				if (fpFYmYhvwgaLAWplPmekypDCGn)
				{
					VYzxGfkwAkfDNnMiEJFRKoaCWSP.color = uQLoRyWjTBxHBIaWbEtCCwJVqiX;
				}
				else
				{
					uQLoRyWjTBxHBIaWbEtCCwJVqiX = VYzxGfkwAkfDNnMiEJFRKoaCWSP.color;
				}
			}
		}

		private void jucOBTNcliWGPvVoCpKQNyFMQnd()
		{
			if (Application.isPlaying)
			{
				if (VYzxGfkwAkfDNnMiEJFRKoaCWSP != null)
				{
					VYzxGfkwAkfDNnMiEJFRKoaCWSP.text = string.Empty;
				}
				VYzxGfkwAkfDNnMiEJFRKoaCWSP = null;
			}
		}

		private void VrzSxkWOCtrBWeyavAOTWOarDVQ()
		{
			lHIrODipuIAyOBOuSQnbHibFzut = new GUIStyle(GUI.skin.label);
			if (qlWWAISCkfaRtwMyHznWGLHlhDj)
			{
				lHIrODipuIAyOBOuSQnbHibFzut.alignment = LLXBCwKhgNCBqvSIBeEwkxcwCeX;
			}
			else
			{
				LLXBCwKhgNCBqvSIBeEwkxcwCeX = lHIrODipuIAyOBOuSQnbHibFzut.alignment;
			}
			if (dAxhWGNIxAdwJcdjSUDSPbIlDAid)
			{
				lHIrODipuIAyOBOuSQnbHibFzut.font = GnGWxyQjDatdCniWCEZIAXkwuIA;
			}
			else
			{
				GnGWxyQjDatdCniWCEZIAXkwuIA = lHIrODipuIAyOBOuSQnbHibFzut.font;
			}
			if (hAnUuiyeOdsILoqYGyowOZylMDz)
			{
				lHIrODipuIAyOBOuSQnbHibFzut.fontSize = kgXMRjngYjZQBAmUxrJTimWiVjp;
			}
			else
			{
				kgXMRjngYjZQBAmUxrJTimWiVjp = lHIrODipuIAyOBOuSQnbHibFzut.fontSize;
			}
			if (tCBPAvoYzZHQvNIZTJraxKBjwiR)
			{
				lHIrODipuIAyOBOuSQnbHibFzut.fontStyle = erxqUBMWqgPlwYyArEADyJFzgdA;
			}
			else
			{
				erxqUBMWqgPlwYyArEADyJFzgdA = lHIrODipuIAyOBOuSQnbHibFzut.fontStyle;
			}
			if (fpFYmYhvwgaLAWplPmekypDCGn)
			{
				lHIrODipuIAyOBOuSQnbHibFzut.normal.textColor = uQLoRyWjTBxHBIaWbEtCCwJVqiX;
			}
			else
			{
				uQLoRyWjTBxHBIaWbEtCCwJVqiX = lHIrODipuIAyOBOuSQnbHibFzut.normal.textColor;
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
