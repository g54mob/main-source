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
		private string PIEGDbAUuMVimHTImcVdyPlhVZeX;

		private GUIStyle UBYyFYiCHffFplkwZKCWGvMRduUn;

		private TextAnchor lXfkcZGnullKFrJhNRgYtACUcuTaA;

		private TextAlignment iGPKXQPrSbrwWbuIvwSUutzhUxcM;

		private float KPEmgLDiHhFbwNxYuiucnZCvQamm;

		private Font kTjXUGJpvZsVvgjVyzLRKUBSqvsp;

		private int VkvumllsgrqXjdHSnuqtZWQEfbdt = -1;

		private FontStyle FNoStfOwGHtayfctuqVpAsiRUvjI;

		private Color KKuCadxDcqyziWqQtAwAenmpuenH = Color.white;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Vector2 _pixelOffset;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useUnityUI;

		private bool KmmPJPttnvCUWitVkdeeYkWEpwZI;

		private bool awVEiPiIEVgvHznqvYcgvOjMqIvxA;

		private bool QipvUNooHLgVagabtvuqFVTVjPPgb;

		private bool VwwFFsfpSmIYQdlrkveQEiVDOuadE;

		private bool hhnBLniVDgWxKjxPuBVFuFWfFimAb;

		private bool tzYxNovQwVOGqOAefblSOyfAiSUw;

		private bool uenFbuqGjCjJjxYgwAtkQkcnZxIh;

		private Text JfotgcOlFnYydJwniFoBUkLhwRdg;

		private bool TZYUTkqIpwbbSQQmAEtHhjnedlLOA;

		private bool lOrDrGjSkvKKhKNyMpXlEZtcnPsvA;

		public string text
		{
			get
			{
				return PIEGDbAUuMVimHTImcVdyPlhVZeX;
			}
			set
			{
				PIEGDbAUuMVimHTImcVdyPlhVZeX = value;
			}
		}

		public TextAnchor anchor
		{
			get
			{
				return lXfkcZGnullKFrJhNRgYtACUcuTaA;
			}
			set
			{
				lXfkcZGnullKFrJhNRgYtACUcuTaA = value;
				KmmPJPttnvCUWitVkdeeYkWEpwZI = true;
				if (UBYyFYiCHffFplkwZKCWGvMRduUn != null)
				{
					UBYyFYiCHffFplkwZKCWGvMRduUn.alignment = value;
				}
			}
		}

		public TextAlignment alignment
		{
			get
			{
				return iGPKXQPrSbrwWbuIvwSUutzhUxcM;
			}
			set
			{
				iGPKXQPrSbrwWbuIvwSUutzhUxcM = value;
				awVEiPiIEVgvHznqvYcgvOjMqIvxA = true;
			}
		}

		public float lineSpacing
		{
			get
			{
				return KPEmgLDiHhFbwNxYuiucnZCvQamm;
			}
			set
			{
				KPEmgLDiHhFbwNxYuiucnZCvQamm = value;
				QipvUNooHLgVagabtvuqFVTVjPPgb = true;
				_ = UBYyFYiCHffFplkwZKCWGvMRduUn;
			}
		}

		public Font font
		{
			get
			{
				return kTjXUGJpvZsVvgjVyzLRKUBSqvsp;
			}
			set
			{
				VwwFFsfpSmIYQdlrkveQEiVDOuadE = true;
				kTjXUGJpvZsVvgjVyzLRKUBSqvsp = value;
				if (UBYyFYiCHffFplkwZKCWGvMRduUn != null)
				{
					UBYyFYiCHffFplkwZKCWGvMRduUn.font = value;
				}
			}
		}

		public int fontSize
		{
			get
			{
				return VkvumllsgrqXjdHSnuqtZWQEfbdt;
			}
			set
			{
				VkvumllsgrqXjdHSnuqtZWQEfbdt = value;
				hhnBLniVDgWxKjxPuBVFuFWfFimAb = true;
				if (UBYyFYiCHffFplkwZKCWGvMRduUn != null)
				{
					UBYyFYiCHffFplkwZKCWGvMRduUn.fontSize = value;
				}
			}
		}

		public FontStyle fontStyle
		{
			get
			{
				return FNoStfOwGHtayfctuqVpAsiRUvjI;
			}
			set
			{
				FNoStfOwGHtayfctuqVpAsiRUvjI = value;
				tzYxNovQwVOGqOAefblSOyfAiSUw = true;
				if (UBYyFYiCHffFplkwZKCWGvMRduUn != null)
				{
					UBYyFYiCHffFplkwZKCWGvMRduUn.fontStyle = value;
				}
			}
		}

		public Color color
		{
			get
			{
				return KKuCadxDcqyziWqQtAwAenmpuenH;
			}
			set
			{
				KKuCadxDcqyziWqQtAwAenmpuenH = value;
				uenFbuqGjCjJjxYgwAtkQkcnZxIh = true;
				if (UBYyFYiCHffFplkwZKCWGvMRduUn != null)
				{
					UBYyFYiCHffFplkwZKCWGvMRduUn.normal.textColor = value;
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
					TZYUTkqIpwbbSQQmAEtHhjnedlLOA = value;
					if (value)
					{
						fEHMarpVqeSXmXbuVWmmjBUqZzZ();
					}
					else
					{
						euMBvAmjZdaHdcndmNHMIKUwFllBA();
					}
				}
			}
		}

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			lOrDrGjSkvKKhKNyMpXlEZtcnPsvA = true;
		}

		[CustomObfuscation(rename = false)]
		private void Start()
		{
			TZYUTkqIpwbbSQQmAEtHhjnedlLOA = _useUnityUI;
			if (_useUnityUI)
			{
				fEHMarpVqeSXmXbuVWmmjBUqZzZ();
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			if (!_useUnityUI)
			{
				if (UBYyFYiCHffFplkwZKCWGvMRduUn == null)
				{
					fvyoHnVPJlYXzBwCzLuvAJFNxAmj();
				}
				if (!string.IsNullOrEmpty(PIEGDbAUuMVimHTImcVdyPlhVZeX))
				{
					Vector2 vector = base.transform.localPosition;
					GUI.Label(new Rect(vector.x * (float)Screen.width + _pixelOffset.x, vector.y * (float)Screen.height + _pixelOffset.y, MathTools.Clamp((float)Screen.width - vector.x * (float)Screen.width, 0f, float.MaxValue), MathTools.Clamp((float)Screen.height - vector.y * (float)Screen.height, 0f, float.MaxValue)), PIEGDbAUuMVimHTImcVdyPlhVZeX, UBYyFYiCHffFplkwZKCWGvMRduUn);
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
			if (JfotgcOlFnYydJwniFoBUkLhwRdg == null)
			{
				Logger.LogError("Text component has been deleted.");
				return;
			}
			RectTransform component = JfotgcOlFnYydJwniFoBUkLhwRdg.GetComponent<RectTransform>();
			if (component.anchoredPosition != _pixelOffset)
			{
				component.anchoredPosition = _pixelOffset;
			}
			JfotgcOlFnYydJwniFoBUkLhwRdg.text = PIEGDbAUuMVimHTImcVdyPlhVZeX;
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			if (lOrDrGjSkvKKhKNyMpXlEZtcnPsvA && _useUnityUI != TZYUTkqIpwbbSQQmAEtHhjnedlLOA)
			{
				TZYUTkqIpwbbSQQmAEtHhjnedlLOA = _useUnityUI;
				if (_useUnityUI)
				{
					fEHMarpVqeSXmXbuVWmmjBUqZzZ();
				}
				else
				{
					euMBvAmjZdaHdcndmNHMIKUwFllBA();
				}
			}
		}

		private void fEHMarpVqeSXmXbuVWmmjBUqZzZ()
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
			JfotgcOlFnYydJwniFoBUkLhwRdg = GetComponent<Text>();
			if (!(JfotgcOlFnYydJwniFoBUkLhwRdg == null))
			{
				return;
			}
			RectTransform rectTransform = base.gameObject.AddComponent<RectTransform>();
			rectTransform.anchorMax = new Vector2(1f, 1f);
			rectTransform.anchorMin = new Vector2(0f, 0f);
			rectTransform.localPosition = Vector2.zero;
			rectTransform.anchoredPosition = Vector2.zero;
			rectTransform.sizeDelta = Vector3.zero;
			JfotgcOlFnYydJwniFoBUkLhwRdg = base.gameObject.AddComponent<Text>();
			JfotgcOlFnYydJwniFoBUkLhwRdg.color = Color.white;
			if (_useUnityUI)
			{
				try
				{
					JfotgcOlFnYydJwniFoBUkLhwRdg.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
				}
				catch
				{
					try
					{
						JfotgcOlFnYydJwniFoBUkLhwRdg.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
					}
					catch
					{
						Logger.LogError("No default font found for GUIText.");
					}
				}
			}
			JfotgcOlFnYydJwniFoBUkLhwRdg.fontSize = 13;
			if (KmmPJPttnvCUWitVkdeeYkWEpwZI)
			{
				JfotgcOlFnYydJwniFoBUkLhwRdg.alignment = lXfkcZGnullKFrJhNRgYtACUcuTaA;
			}
			else
			{
				lXfkcZGnullKFrJhNRgYtACUcuTaA = JfotgcOlFnYydJwniFoBUkLhwRdg.alignment;
			}
			if (VwwFFsfpSmIYQdlrkveQEiVDOuadE)
			{
				JfotgcOlFnYydJwniFoBUkLhwRdg.font = kTjXUGJpvZsVvgjVyzLRKUBSqvsp;
			}
			else
			{
				kTjXUGJpvZsVvgjVyzLRKUBSqvsp = JfotgcOlFnYydJwniFoBUkLhwRdg.font;
			}
			if (hhnBLniVDgWxKjxPuBVFuFWfFimAb)
			{
				JfotgcOlFnYydJwniFoBUkLhwRdg.fontSize = VkvumllsgrqXjdHSnuqtZWQEfbdt;
			}
			else
			{
				VkvumllsgrqXjdHSnuqtZWQEfbdt = JfotgcOlFnYydJwniFoBUkLhwRdg.fontSize;
			}
			if (tzYxNovQwVOGqOAefblSOyfAiSUw)
			{
				JfotgcOlFnYydJwniFoBUkLhwRdg.fontStyle = FNoStfOwGHtayfctuqVpAsiRUvjI;
			}
			else
			{
				FNoStfOwGHtayfctuqVpAsiRUvjI = JfotgcOlFnYydJwniFoBUkLhwRdg.fontStyle;
			}
			if (uenFbuqGjCjJjxYgwAtkQkcnZxIh)
			{
				JfotgcOlFnYydJwniFoBUkLhwRdg.color = KKuCadxDcqyziWqQtAwAenmpuenH;
			}
			else
			{
				KKuCadxDcqyziWqQtAwAenmpuenH = JfotgcOlFnYydJwniFoBUkLhwRdg.color;
			}
		}

		private void euMBvAmjZdaHdcndmNHMIKUwFllBA()
		{
			if (Application.isPlaying)
			{
				if (JfotgcOlFnYydJwniFoBUkLhwRdg != null)
				{
					JfotgcOlFnYydJwniFoBUkLhwRdg.text = string.Empty;
				}
				JfotgcOlFnYydJwniFoBUkLhwRdg = null;
			}
		}

		private void fvyoHnVPJlYXzBwCzLuvAJFNxAmj()
		{
			UBYyFYiCHffFplkwZKCWGvMRduUn = new GUIStyle(GUI.skin.label);
			if (KmmPJPttnvCUWitVkdeeYkWEpwZI)
			{
				UBYyFYiCHffFplkwZKCWGvMRduUn.alignment = lXfkcZGnullKFrJhNRgYtACUcuTaA;
			}
			else
			{
				lXfkcZGnullKFrJhNRgYtACUcuTaA = UBYyFYiCHffFplkwZKCWGvMRduUn.alignment;
			}
			if (VwwFFsfpSmIYQdlrkveQEiVDOuadE)
			{
				UBYyFYiCHffFplkwZKCWGvMRduUn.font = kTjXUGJpvZsVvgjVyzLRKUBSqvsp;
			}
			else
			{
				kTjXUGJpvZsVvgjVyzLRKUBSqvsp = UBYyFYiCHffFplkwZKCWGvMRduUn.font;
			}
			if (hhnBLniVDgWxKjxPuBVFuFWfFimAb)
			{
				UBYyFYiCHffFplkwZKCWGvMRduUn.fontSize = VkvumllsgrqXjdHSnuqtZWQEfbdt;
			}
			else
			{
				VkvumllsgrqXjdHSnuqtZWQEfbdt = UBYyFYiCHffFplkwZKCWGvMRduUn.fontSize;
			}
			if (tzYxNovQwVOGqOAefblSOyfAiSUw)
			{
				UBYyFYiCHffFplkwZKCWGvMRduUn.fontStyle = FNoStfOwGHtayfctuqVpAsiRUvjI;
			}
			else
			{
				FNoStfOwGHtayfctuqVpAsiRUvjI = UBYyFYiCHffFplkwZKCWGvMRduUn.fontStyle;
			}
			if (uenFbuqGjCjJjxYgwAtkQkcnZxIh)
			{
				UBYyFYiCHffFplkwZKCWGvMRduUn.normal.textColor = KKuCadxDcqyziWqQtAwAenmpuenH;
			}
			else
			{
				KKuCadxDcqyziWqQtAwAenmpuenH = UBYyFYiCHffFplkwZKCWGvMRduUn.normal.textColor;
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
