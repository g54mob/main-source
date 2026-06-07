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
		private string ykmnYSbzwIBEwpiWHBYxkuUNIEHT;

		private GUIStyle RSMwoBWSmzAgxhfGkCLygdWrKhFIA;

		private TextAnchor rWBpIciUcusqBJZgbMvrSOFMBYtl;

		private TextAlignment qEAUhqdtWhvSqAtmZnscXDxXVCeI;

		private float ofwuDrhxTNWcJGcAcnRZEffdIlLW;

		private Font sPStBgoEFHaDlaRowwUTauPWuwcmA;

		private int GCVpRrDVAKQbcoMkNDuEKSXWeJDM = -1;

		private FontStyle UTtRLBwcKBPeZeivTHfOWFkPtCkH;

		private Color WLHWjigsDiMLkyesLXqToMqhbwdy = Color.white;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Vector2 _pixelOffset;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _useUnityUI;

		private bool GaCrJEwSwSBSSGAUrMkZyPiPctNP;

		private bool tcoiGJZSvyeNjgiDtWdBLmLKNRodb;

		private bool pxFFGShLVQBzYHZRCyEOJBsUDqiq;

		private bool HevFgKItxpXMoWWTsvQVqhrHmAKjA;

		private bool BIlhxwCCUCqEyKcbqrcheKHZWENm;

		private bool XgRFSjUedieYYxtFnwgrTicTqxhh;

		private bool DuxjOwyklFsUassPXdEjIqQxBETn;

		private Text pBzVvzMGWRhJkZLEeAWUiaDyKTdG;

		private bool jrsRdZHzVfCskERZQQSzMotFRISS;

		private bool QrYfdYHdSqNhzyhPeEFnQGBvvQjUA;

		public string text
		{
			get
			{
				return ykmnYSbzwIBEwpiWHBYxkuUNIEHT;
			}
			set
			{
				ykmnYSbzwIBEwpiWHBYxkuUNIEHT = value;
			}
		}

		public TextAnchor anchor
		{
			get
			{
				return rWBpIciUcusqBJZgbMvrSOFMBYtl;
			}
			set
			{
				rWBpIciUcusqBJZgbMvrSOFMBYtl = value;
				GaCrJEwSwSBSSGAUrMkZyPiPctNP = true;
				if (RSMwoBWSmzAgxhfGkCLygdWrKhFIA != null)
				{
					RSMwoBWSmzAgxhfGkCLygdWrKhFIA.alignment = value;
				}
			}
		}

		public TextAlignment alignment
		{
			get
			{
				return qEAUhqdtWhvSqAtmZnscXDxXVCeI;
			}
			set
			{
				qEAUhqdtWhvSqAtmZnscXDxXVCeI = value;
				tcoiGJZSvyeNjgiDtWdBLmLKNRodb = true;
			}
		}

		public float lineSpacing
		{
			get
			{
				return ofwuDrhxTNWcJGcAcnRZEffdIlLW;
			}
			set
			{
				ofwuDrhxTNWcJGcAcnRZEffdIlLW = value;
				pxFFGShLVQBzYHZRCyEOJBsUDqiq = true;
				_ = RSMwoBWSmzAgxhfGkCLygdWrKhFIA;
			}
		}

		public Font font
		{
			get
			{
				return sPStBgoEFHaDlaRowwUTauPWuwcmA;
			}
			set
			{
				HevFgKItxpXMoWWTsvQVqhrHmAKjA = true;
				sPStBgoEFHaDlaRowwUTauPWuwcmA = value;
				if (RSMwoBWSmzAgxhfGkCLygdWrKhFIA != null)
				{
					RSMwoBWSmzAgxhfGkCLygdWrKhFIA.font = value;
				}
			}
		}

		public int fontSize
		{
			get
			{
				return GCVpRrDVAKQbcoMkNDuEKSXWeJDM;
			}
			set
			{
				GCVpRrDVAKQbcoMkNDuEKSXWeJDM = value;
				BIlhxwCCUCqEyKcbqrcheKHZWENm = true;
				if (RSMwoBWSmzAgxhfGkCLygdWrKhFIA != null)
				{
					RSMwoBWSmzAgxhfGkCLygdWrKhFIA.fontSize = value;
				}
			}
		}

		public FontStyle fontStyle
		{
			get
			{
				return UTtRLBwcKBPeZeivTHfOWFkPtCkH;
			}
			set
			{
				UTtRLBwcKBPeZeivTHfOWFkPtCkH = value;
				XgRFSjUedieYYxtFnwgrTicTqxhh = true;
				if (RSMwoBWSmzAgxhfGkCLygdWrKhFIA != null)
				{
					RSMwoBWSmzAgxhfGkCLygdWrKhFIA.fontStyle = value;
				}
			}
		}

		public Color color
		{
			get
			{
				return WLHWjigsDiMLkyesLXqToMqhbwdy;
			}
			set
			{
				WLHWjigsDiMLkyesLXqToMqhbwdy = value;
				DuxjOwyklFsUassPXdEjIqQxBETn = true;
				if (RSMwoBWSmzAgxhfGkCLygdWrKhFIA != null)
				{
					RSMwoBWSmzAgxhfGkCLygdWrKhFIA.normal.textColor = value;
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
					jrsRdZHzVfCskERZQQSzMotFRISS = value;
					if (value)
					{
						OAOZOjjiGRiDgmPKxSYwbQpsEXaI();
					}
					else
					{
						XfySbLvdlHeMgPfQcVRBzHwsFtZw();
					}
				}
			}
		}

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			QrYfdYHdSqNhzyhPeEFnQGBvvQjUA = true;
		}

		[CustomObfuscation(rename = false)]
		private void Start()
		{
			jrsRdZHzVfCskERZQQSzMotFRISS = _useUnityUI;
			if (_useUnityUI)
			{
				OAOZOjjiGRiDgmPKxSYwbQpsEXaI();
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			if (!_useUnityUI)
			{
				if (RSMwoBWSmzAgxhfGkCLygdWrKhFIA == null)
				{
					nJveUwapSSrhxUkAZDZUgnTXBNei();
				}
				if (!string.IsNullOrEmpty(ykmnYSbzwIBEwpiWHBYxkuUNIEHT))
				{
					Vector2 vector = base.transform.localPosition;
					GUI.Label(new Rect(vector.x * (float)Screen.width + _pixelOffset.x, vector.y * (float)Screen.height + _pixelOffset.y, MathTools.Clamp((float)Screen.width - vector.x * (float)Screen.width, 0f, float.MaxValue), MathTools.Clamp((float)Screen.height - vector.y * (float)Screen.height, 0f, float.MaxValue)), ykmnYSbzwIBEwpiWHBYxkuUNIEHT, RSMwoBWSmzAgxhfGkCLygdWrKhFIA);
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
			if (pBzVvzMGWRhJkZLEeAWUiaDyKTdG == null)
			{
				Logger.LogError("Text component has been deleted.");
				return;
			}
			RectTransform component = pBzVvzMGWRhJkZLEeAWUiaDyKTdG.GetComponent<RectTransform>();
			if (component.anchoredPosition != _pixelOffset)
			{
				component.anchoredPosition = _pixelOffset;
			}
			pBzVvzMGWRhJkZLEeAWUiaDyKTdG.text = ykmnYSbzwIBEwpiWHBYxkuUNIEHT;
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			if (QrYfdYHdSqNhzyhPeEFnQGBvvQjUA && _useUnityUI != jrsRdZHzVfCskERZQQSzMotFRISS)
			{
				jrsRdZHzVfCskERZQQSzMotFRISS = _useUnityUI;
				if (_useUnityUI)
				{
					OAOZOjjiGRiDgmPKxSYwbQpsEXaI();
				}
				else
				{
					XfySbLvdlHeMgPfQcVRBzHwsFtZw();
				}
			}
		}

		private void OAOZOjjiGRiDgmPKxSYwbQpsEXaI()
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
			pBzVvzMGWRhJkZLEeAWUiaDyKTdG = GetComponent<Text>();
			if (pBzVvzMGWRhJkZLEeAWUiaDyKTdG == null)
			{
				RectTransform rectTransform = base.gameObject.AddComponent<RectTransform>();
				rectTransform.anchorMax = new Vector2(1f, 1f);
				rectTransform.anchorMin = new Vector2(0f, 0f);
				rectTransform.localPosition = Vector2.zero;
				rectTransform.anchoredPosition = Vector2.zero;
				rectTransform.sizeDelta = Vector3.zero;
				pBzVvzMGWRhJkZLEeAWUiaDyKTdG = base.gameObject.AddComponent<Text>();
				pBzVvzMGWRhJkZLEeAWUiaDyKTdG.color = Color.white;
				pBzVvzMGWRhJkZLEeAWUiaDyKTdG.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
				pBzVvzMGWRhJkZLEeAWUiaDyKTdG.fontSize = 13;
				if (GaCrJEwSwSBSSGAUrMkZyPiPctNP)
				{
					pBzVvzMGWRhJkZLEeAWUiaDyKTdG.alignment = rWBpIciUcusqBJZgbMvrSOFMBYtl;
				}
				else
				{
					rWBpIciUcusqBJZgbMvrSOFMBYtl = pBzVvzMGWRhJkZLEeAWUiaDyKTdG.alignment;
				}
				if (HevFgKItxpXMoWWTsvQVqhrHmAKjA)
				{
					pBzVvzMGWRhJkZLEeAWUiaDyKTdG.font = sPStBgoEFHaDlaRowwUTauPWuwcmA;
				}
				else
				{
					sPStBgoEFHaDlaRowwUTauPWuwcmA = pBzVvzMGWRhJkZLEeAWUiaDyKTdG.font;
				}
				if (BIlhxwCCUCqEyKcbqrcheKHZWENm)
				{
					pBzVvzMGWRhJkZLEeAWUiaDyKTdG.fontSize = GCVpRrDVAKQbcoMkNDuEKSXWeJDM;
				}
				else
				{
					GCVpRrDVAKQbcoMkNDuEKSXWeJDM = pBzVvzMGWRhJkZLEeAWUiaDyKTdG.fontSize;
				}
				if (XgRFSjUedieYYxtFnwgrTicTqxhh)
				{
					pBzVvzMGWRhJkZLEeAWUiaDyKTdG.fontStyle = UTtRLBwcKBPeZeivTHfOWFkPtCkH;
				}
				else
				{
					UTtRLBwcKBPeZeivTHfOWFkPtCkH = pBzVvzMGWRhJkZLEeAWUiaDyKTdG.fontStyle;
				}
				if (DuxjOwyklFsUassPXdEjIqQxBETn)
				{
					pBzVvzMGWRhJkZLEeAWUiaDyKTdG.color = WLHWjigsDiMLkyesLXqToMqhbwdy;
				}
				else
				{
					WLHWjigsDiMLkyesLXqToMqhbwdy = pBzVvzMGWRhJkZLEeAWUiaDyKTdG.color;
				}
			}
		}

		private void XfySbLvdlHeMgPfQcVRBzHwsFtZw()
		{
			if (Application.isPlaying)
			{
				if (pBzVvzMGWRhJkZLEeAWUiaDyKTdG != null)
				{
					pBzVvzMGWRhJkZLEeAWUiaDyKTdG.text = string.Empty;
				}
				pBzVvzMGWRhJkZLEeAWUiaDyKTdG = null;
			}
		}

		private void nJveUwapSSrhxUkAZDZUgnTXBNei()
		{
			RSMwoBWSmzAgxhfGkCLygdWrKhFIA = new GUIStyle(GUI.skin.label);
			if (GaCrJEwSwSBSSGAUrMkZyPiPctNP)
			{
				RSMwoBWSmzAgxhfGkCLygdWrKhFIA.alignment = rWBpIciUcusqBJZgbMvrSOFMBYtl;
			}
			else
			{
				rWBpIciUcusqBJZgbMvrSOFMBYtl = RSMwoBWSmzAgxhfGkCLygdWrKhFIA.alignment;
			}
			if (HevFgKItxpXMoWWTsvQVqhrHmAKjA)
			{
				RSMwoBWSmzAgxhfGkCLygdWrKhFIA.font = sPStBgoEFHaDlaRowwUTauPWuwcmA;
			}
			else
			{
				sPStBgoEFHaDlaRowwUTauPWuwcmA = RSMwoBWSmzAgxhfGkCLygdWrKhFIA.font;
			}
			if (BIlhxwCCUCqEyKcbqrcheKHZWENm)
			{
				RSMwoBWSmzAgxhfGkCLygdWrKhFIA.fontSize = GCVpRrDVAKQbcoMkNDuEKSXWeJDM;
			}
			else
			{
				GCVpRrDVAKQbcoMkNDuEKSXWeJDM = RSMwoBWSmzAgxhfGkCLygdWrKhFIA.fontSize;
			}
			if (XgRFSjUedieYYxtFnwgrTicTqxhh)
			{
				RSMwoBWSmzAgxhfGkCLygdWrKhFIA.fontStyle = UTtRLBwcKBPeZeivTHfOWFkPtCkH;
			}
			else
			{
				UTtRLBwcKBPeZeivTHfOWFkPtCkH = RSMwoBWSmzAgxhfGkCLygdWrKhFIA.fontStyle;
			}
			if (DuxjOwyklFsUassPXdEjIqQxBETn)
			{
				RSMwoBWSmzAgxhfGkCLygdWrKhFIA.normal.textColor = WLHWjigsDiMLkyesLXqToMqhbwdy;
			}
			else
			{
				WLHWjigsDiMLkyesLXqToMqhbwdy = RSMwoBWSmzAgxhfGkCLygdWrKhFIA.normal.textColor;
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
