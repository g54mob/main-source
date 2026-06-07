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
		private string CIqDUCMQgXHkufXZkrDTiXFQYlulA;

		private GUIStyle VCizHtueZsTghlNjPKlgSGocMoUL;

		private TextAnchor ecRdjsEYqwEEFtrwFdyilfqdqEFlA;

		private TextAlignment nKbaWpdDQoloGipZazCsmeDrETggc;

		private float FkmpXuPBTaxPwPLmumdKvioSqCqF;

		private Font jrRPXxBCtMMXnyuEcnRzOtxngHmq;

		private int IiXPjSbxseCPhpbDlxuLTAsfYJbp = -1;

		private FontStyle MSWLhCKvoEnRenYksaJRSxIsiMnf;

		private Color TNAVDCtaehbaeGHJtVWyeOOUKSbq = Color.white;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Vector2 _pixelOffset;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _useUnityUI;

		private bool JNAMuqzijmEaYkYeenRCIByrTUXE;

		private bool tOzHhoSfGCmdBjRpzdcASnBlsado;

		private bool DMDsFaquPIbVocLobhaSNtxkflDIA;

		private bool YyUeOZhmAntWSxFilxykmBdblYxs;

		private bool waBIIQREPdtzSxKGgGFbRwkGHCit;

		private bool aAqpMNfnaMjUoURtladyJGVbJcOkA;

		private bool rkDQaJgHzZxojtabqdIAMYUQDrYR;

		private Text CJSiSTQPTkAgtBEwsLMfUDpEGatL;

		private bool UwqMCTsIjpDbQYalIurrrEZDnDJR;

		private bool mrJJczIMsqgEfXNfGdDLADNDRbmwA;

		public string text
		{
			get
			{
				return CIqDUCMQgXHkufXZkrDTiXFQYlulA;
			}
			set
			{
				CIqDUCMQgXHkufXZkrDTiXFQYlulA = value;
			}
		}

		public TextAnchor anchor
		{
			get
			{
				return ecRdjsEYqwEEFtrwFdyilfqdqEFlA;
			}
			set
			{
				ecRdjsEYqwEEFtrwFdyilfqdqEFlA = value;
				JNAMuqzijmEaYkYeenRCIByrTUXE = true;
				if (VCizHtueZsTghlNjPKlgSGocMoUL != null)
				{
					VCizHtueZsTghlNjPKlgSGocMoUL.alignment = value;
				}
			}
		}

		public TextAlignment alignment
		{
			get
			{
				return nKbaWpdDQoloGipZazCsmeDrETggc;
			}
			set
			{
				nKbaWpdDQoloGipZazCsmeDrETggc = value;
				tOzHhoSfGCmdBjRpzdcASnBlsado = true;
			}
		}

		public float lineSpacing
		{
			get
			{
				return FkmpXuPBTaxPwPLmumdKvioSqCqF;
			}
			set
			{
				FkmpXuPBTaxPwPLmumdKvioSqCqF = value;
				DMDsFaquPIbVocLobhaSNtxkflDIA = true;
				_ = VCizHtueZsTghlNjPKlgSGocMoUL;
			}
		}

		public Font font
		{
			get
			{
				return jrRPXxBCtMMXnyuEcnRzOtxngHmq;
			}
			set
			{
				YyUeOZhmAntWSxFilxykmBdblYxs = true;
				jrRPXxBCtMMXnyuEcnRzOtxngHmq = value;
				if (VCizHtueZsTghlNjPKlgSGocMoUL != null)
				{
					VCizHtueZsTghlNjPKlgSGocMoUL.font = value;
				}
			}
		}

		public int fontSize
		{
			get
			{
				return IiXPjSbxseCPhpbDlxuLTAsfYJbp;
			}
			set
			{
				IiXPjSbxseCPhpbDlxuLTAsfYJbp = value;
				waBIIQREPdtzSxKGgGFbRwkGHCit = true;
				if (VCizHtueZsTghlNjPKlgSGocMoUL != null)
				{
					VCizHtueZsTghlNjPKlgSGocMoUL.fontSize = value;
				}
			}
		}

		public FontStyle fontStyle
		{
			get
			{
				return MSWLhCKvoEnRenYksaJRSxIsiMnf;
			}
			set
			{
				MSWLhCKvoEnRenYksaJRSxIsiMnf = value;
				aAqpMNfnaMjUoURtladyJGVbJcOkA = true;
				if (VCizHtueZsTghlNjPKlgSGocMoUL != null)
				{
					VCizHtueZsTghlNjPKlgSGocMoUL.fontStyle = value;
				}
			}
		}

		public Color color
		{
			get
			{
				return TNAVDCtaehbaeGHJtVWyeOOUKSbq;
			}
			set
			{
				TNAVDCtaehbaeGHJtVWyeOOUKSbq = value;
				rkDQaJgHzZxojtabqdIAMYUQDrYR = true;
				if (VCizHtueZsTghlNjPKlgSGocMoUL != null)
				{
					VCizHtueZsTghlNjPKlgSGocMoUL.normal.textColor = value;
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
					UwqMCTsIjpDbQYalIurrrEZDnDJR = value;
					if (value)
					{
						qvqRRBnaBldYFHHciaEEtWzbUnlM();
					}
					else
					{
						vunYnAqReqFlNcqimBcFGqLmBdsA();
					}
				}
			}
		}

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			mrJJczIMsqgEfXNfGdDLADNDRbmwA = true;
		}

		[CustomObfuscation(rename = false)]
		private void Start()
		{
			UwqMCTsIjpDbQYalIurrrEZDnDJR = _useUnityUI;
			if (_useUnityUI)
			{
				qvqRRBnaBldYFHHciaEEtWzbUnlM();
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			if (!_useUnityUI)
			{
				if (VCizHtueZsTghlNjPKlgSGocMoUL == null)
				{
					qrSTGOFoNkjUjhFDznBVrKxorVuLA();
				}
				if (!string.IsNullOrEmpty(CIqDUCMQgXHkufXZkrDTiXFQYlulA))
				{
					Vector2 vector = base.transform.localPosition;
					GUI.Label(new Rect(vector.x * (float)Screen.width + _pixelOffset.x, vector.y * (float)Screen.height + _pixelOffset.y, MathTools.Clamp((float)Screen.width - vector.x * (float)Screen.width, 0f, float.MaxValue), MathTools.Clamp((float)Screen.height - vector.y * (float)Screen.height, 0f, float.MaxValue)), CIqDUCMQgXHkufXZkrDTiXFQYlulA, VCizHtueZsTghlNjPKlgSGocMoUL);
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
			if (CJSiSTQPTkAgtBEwsLMfUDpEGatL == null)
			{
				Logger.LogError("Text component has been deleted.");
				return;
			}
			RectTransform component = CJSiSTQPTkAgtBEwsLMfUDpEGatL.GetComponent<RectTransform>();
			if (component.anchoredPosition != _pixelOffset)
			{
				component.anchoredPosition = _pixelOffset;
			}
			CJSiSTQPTkAgtBEwsLMfUDpEGatL.text = CIqDUCMQgXHkufXZkrDTiXFQYlulA;
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			if (mrJJczIMsqgEfXNfGdDLADNDRbmwA && _useUnityUI != UwqMCTsIjpDbQYalIurrrEZDnDJR)
			{
				UwqMCTsIjpDbQYalIurrrEZDnDJR = _useUnityUI;
				if (_useUnityUI)
				{
					qvqRRBnaBldYFHHciaEEtWzbUnlM();
				}
				else
				{
					vunYnAqReqFlNcqimBcFGqLmBdsA();
				}
			}
		}

		private void qvqRRBnaBldYFHHciaEEtWzbUnlM()
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
			CJSiSTQPTkAgtBEwsLMfUDpEGatL = GetComponent<Text>();
			if (CJSiSTQPTkAgtBEwsLMfUDpEGatL == null)
			{
				RectTransform rectTransform = base.gameObject.AddComponent<RectTransform>();
				rectTransform.anchorMax = new Vector2(1f, 1f);
				rectTransform.anchorMin = new Vector2(0f, 0f);
				rectTransform.localPosition = Vector2.zero;
				rectTransform.anchoredPosition = Vector2.zero;
				rectTransform.sizeDelta = Vector3.zero;
				CJSiSTQPTkAgtBEwsLMfUDpEGatL = base.gameObject.AddComponent<Text>();
				CJSiSTQPTkAgtBEwsLMfUDpEGatL.color = Color.white;
				CJSiSTQPTkAgtBEwsLMfUDpEGatL.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
				CJSiSTQPTkAgtBEwsLMfUDpEGatL.fontSize = 13;
				if (JNAMuqzijmEaYkYeenRCIByrTUXE)
				{
					CJSiSTQPTkAgtBEwsLMfUDpEGatL.alignment = ecRdjsEYqwEEFtrwFdyilfqdqEFlA;
				}
				else
				{
					ecRdjsEYqwEEFtrwFdyilfqdqEFlA = CJSiSTQPTkAgtBEwsLMfUDpEGatL.alignment;
				}
				if (YyUeOZhmAntWSxFilxykmBdblYxs)
				{
					CJSiSTQPTkAgtBEwsLMfUDpEGatL.font = jrRPXxBCtMMXnyuEcnRzOtxngHmq;
				}
				else
				{
					jrRPXxBCtMMXnyuEcnRzOtxngHmq = CJSiSTQPTkAgtBEwsLMfUDpEGatL.font;
				}
				if (waBIIQREPdtzSxKGgGFbRwkGHCit)
				{
					CJSiSTQPTkAgtBEwsLMfUDpEGatL.fontSize = IiXPjSbxseCPhpbDlxuLTAsfYJbp;
				}
				else
				{
					IiXPjSbxseCPhpbDlxuLTAsfYJbp = CJSiSTQPTkAgtBEwsLMfUDpEGatL.fontSize;
				}
				if (aAqpMNfnaMjUoURtladyJGVbJcOkA)
				{
					CJSiSTQPTkAgtBEwsLMfUDpEGatL.fontStyle = MSWLhCKvoEnRenYksaJRSxIsiMnf;
				}
				else
				{
					MSWLhCKvoEnRenYksaJRSxIsiMnf = CJSiSTQPTkAgtBEwsLMfUDpEGatL.fontStyle;
				}
				if (rkDQaJgHzZxojtabqdIAMYUQDrYR)
				{
					CJSiSTQPTkAgtBEwsLMfUDpEGatL.color = TNAVDCtaehbaeGHJtVWyeOOUKSbq;
				}
				else
				{
					TNAVDCtaehbaeGHJtVWyeOOUKSbq = CJSiSTQPTkAgtBEwsLMfUDpEGatL.color;
				}
			}
		}

		private void vunYnAqReqFlNcqimBcFGqLmBdsA()
		{
			if (Application.isPlaying)
			{
				if (CJSiSTQPTkAgtBEwsLMfUDpEGatL != null)
				{
					CJSiSTQPTkAgtBEwsLMfUDpEGatL.text = string.Empty;
				}
				CJSiSTQPTkAgtBEwsLMfUDpEGatL = null;
			}
		}

		private void qrSTGOFoNkjUjhFDznBVrKxorVuLA()
		{
			VCizHtueZsTghlNjPKlgSGocMoUL = new GUIStyle(GUI.skin.label);
			if (JNAMuqzijmEaYkYeenRCIByrTUXE)
			{
				VCizHtueZsTghlNjPKlgSGocMoUL.alignment = ecRdjsEYqwEEFtrwFdyilfqdqEFlA;
			}
			else
			{
				ecRdjsEYqwEEFtrwFdyilfqdqEFlA = VCizHtueZsTghlNjPKlgSGocMoUL.alignment;
			}
			if (YyUeOZhmAntWSxFilxykmBdblYxs)
			{
				VCizHtueZsTghlNjPKlgSGocMoUL.font = jrRPXxBCtMMXnyuEcnRzOtxngHmq;
			}
			else
			{
				jrRPXxBCtMMXnyuEcnRzOtxngHmq = VCizHtueZsTghlNjPKlgSGocMoUL.font;
			}
			if (waBIIQREPdtzSxKGgGFbRwkGHCit)
			{
				VCizHtueZsTghlNjPKlgSGocMoUL.fontSize = IiXPjSbxseCPhpbDlxuLTAsfYJbp;
			}
			else
			{
				IiXPjSbxseCPhpbDlxuLTAsfYJbp = VCizHtueZsTghlNjPKlgSGocMoUL.fontSize;
			}
			if (aAqpMNfnaMjUoURtladyJGVbJcOkA)
			{
				VCizHtueZsTghlNjPKlgSGocMoUL.fontStyle = MSWLhCKvoEnRenYksaJRSxIsiMnf;
			}
			else
			{
				MSWLhCKvoEnRenYksaJRSxIsiMnf = VCizHtueZsTghlNjPKlgSGocMoUL.fontStyle;
			}
			if (rkDQaJgHzZxojtabqdIAMYUQDrYR)
			{
				VCizHtueZsTghlNjPKlgSGocMoUL.normal.textColor = TNAVDCtaehbaeGHJtVWyeOOUKSbq;
			}
			else
			{
				TNAVDCtaehbaeGHJtVWyeOOUKSbq = VCizHtueZsTghlNjPKlgSGocMoUL.normal.textColor;
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
