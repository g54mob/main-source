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
		private string qNACakqVLwsRRIoGiuTfCYOPEIZ;

		private GUIStyle ZbuUbQDFZThIYMMoRKiVNMWlfRP;

		private TextAnchor bzhqpOlBFEefeawqUGaluDPKGStb;

		private TextAlignment ypqJgEuohRpeFvJksEykrIfDHNwi;

		private float mkYgGFEoAnnTsetIbZmZiudhvdTO;

		private Font eAyzjMdoFhEYEgmoRRHTIDiOcAo;

		private int KttadTQIzcEmXXqmiPbCyEBEzFL = -1;

		private FontStyle EyXftxEfJbzQycDqoTKSHaiXQlcH;

		private Color AEbNHMhmDGIdFPgkerpPWiidIux = Color.white;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Vector2 _pixelOffset;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _useUnityUI;

		private bool IyuxgophNwGFnfQEIHtLFUgVfzHn;

		private bool jnGcnfMYWOEGMBNeSowDUHgGPPq;

		private bool bxxipegqiuiyhgxNxbjSfqtGife;

		private bool TNBAHqebOPXzFvfXRRnBHsjDYnQ;

		private bool RnDgBKcVzgpzRhKwHAwjfOTRNMP;

		private bool FjvDvZCZYEQvbRGbCpvxhVcJgqxj;

		private bool XTPauChYTxPgJFaNsXGnctYfUCH;

		private Text bSDJlLPPjlbkHupWHFVUQXFgTEj;

		private bool hhUDovGYiTdZTzpHnTnpcwjLQJQ;

		private bool YGyTLoahjIowSAHmDSFheJNtEkf;

		public string text
		{
			get
			{
				return qNACakqVLwsRRIoGiuTfCYOPEIZ;
			}
			set
			{
				qNACakqVLwsRRIoGiuTfCYOPEIZ = value;
			}
		}

		public TextAnchor anchor
		{
			get
			{
				return bzhqpOlBFEefeawqUGaluDPKGStb;
			}
			set
			{
				bzhqpOlBFEefeawqUGaluDPKGStb = value;
				IyuxgophNwGFnfQEIHtLFUgVfzHn = true;
				if (ZbuUbQDFZThIYMMoRKiVNMWlfRP != null)
				{
					ZbuUbQDFZThIYMMoRKiVNMWlfRP.alignment = value;
				}
			}
		}

		public TextAlignment alignment
		{
			get
			{
				return ypqJgEuohRpeFvJksEykrIfDHNwi;
			}
			set
			{
				ypqJgEuohRpeFvJksEykrIfDHNwi = value;
				jnGcnfMYWOEGMBNeSowDUHgGPPq = true;
			}
		}

		public float lineSpacing
		{
			get
			{
				return mkYgGFEoAnnTsetIbZmZiudhvdTO;
			}
			set
			{
				mkYgGFEoAnnTsetIbZmZiudhvdTO = value;
				bxxipegqiuiyhgxNxbjSfqtGife = true;
				_ = ZbuUbQDFZThIYMMoRKiVNMWlfRP;
			}
		}

		public Font font
		{
			get
			{
				return eAyzjMdoFhEYEgmoRRHTIDiOcAo;
			}
			set
			{
				TNBAHqebOPXzFvfXRRnBHsjDYnQ = true;
				eAyzjMdoFhEYEgmoRRHTIDiOcAo = value;
				if (ZbuUbQDFZThIYMMoRKiVNMWlfRP != null)
				{
					ZbuUbQDFZThIYMMoRKiVNMWlfRP.font = value;
				}
			}
		}

		public int fontSize
		{
			get
			{
				return KttadTQIzcEmXXqmiPbCyEBEzFL;
			}
			set
			{
				KttadTQIzcEmXXqmiPbCyEBEzFL = value;
				RnDgBKcVzgpzRhKwHAwjfOTRNMP = true;
				if (ZbuUbQDFZThIYMMoRKiVNMWlfRP != null)
				{
					ZbuUbQDFZThIYMMoRKiVNMWlfRP.fontSize = value;
				}
			}
		}

		public FontStyle fontStyle
		{
			get
			{
				return EyXftxEfJbzQycDqoTKSHaiXQlcH;
			}
			set
			{
				EyXftxEfJbzQycDqoTKSHaiXQlcH = value;
				FjvDvZCZYEQvbRGbCpvxhVcJgqxj = true;
				if (ZbuUbQDFZThIYMMoRKiVNMWlfRP != null)
				{
					ZbuUbQDFZThIYMMoRKiVNMWlfRP.fontStyle = value;
				}
			}
		}

		public Color color
		{
			get
			{
				return AEbNHMhmDGIdFPgkerpPWiidIux;
			}
			set
			{
				AEbNHMhmDGIdFPgkerpPWiidIux = value;
				XTPauChYTxPgJFaNsXGnctYfUCH = true;
				if (ZbuUbQDFZThIYMMoRKiVNMWlfRP != null)
				{
					ZbuUbQDFZThIYMMoRKiVNMWlfRP.normal.textColor = value;
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
					hhUDovGYiTdZTzpHnTnpcwjLQJQ = value;
					if (value)
					{
						MOeEtPKqljQfLiTIUkByBLzgiAgj();
					}
					else
					{
						FkOEupbyOvRnDimEZuYHkBscttVr();
					}
				}
			}
		}

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			YGyTLoahjIowSAHmDSFheJNtEkf = true;
		}

		[CustomObfuscation(rename = false)]
		private void Start()
		{
			hhUDovGYiTdZTzpHnTnpcwjLQJQ = _useUnityUI;
			if (_useUnityUI)
			{
				MOeEtPKqljQfLiTIUkByBLzgiAgj();
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			if (!_useUnityUI)
			{
				if (ZbuUbQDFZThIYMMoRKiVNMWlfRP == null)
				{
					dKZDSEbVdyNsYtqGieYUSKJTlLk();
				}
				if (!string.IsNullOrEmpty(qNACakqVLwsRRIoGiuTfCYOPEIZ))
				{
					Vector2 vector = base.transform.localPosition;
					Rect position = new Rect(vector.x * (float)Screen.width + _pixelOffset.x, vector.y * (float)Screen.height + _pixelOffset.y, MathTools.Clamp((float)Screen.width - vector.x * (float)Screen.width, 0f, float.MaxValue), MathTools.Clamp((float)Screen.height - vector.y * (float)Screen.height, 0f, float.MaxValue));
					GUI.Label(position, qNACakqVLwsRRIoGiuTfCYOPEIZ, ZbuUbQDFZThIYMMoRKiVNMWlfRP);
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
			if (bSDJlLPPjlbkHupWHFVUQXFgTEj == null)
			{
				Logger.LogError("Text component has been deleted.");
				return;
			}
			RectTransform component = bSDJlLPPjlbkHupWHFVUQXFgTEj.GetComponent<RectTransform>();
			if (component.anchoredPosition != _pixelOffset)
			{
				component.anchoredPosition = _pixelOffset;
			}
			bSDJlLPPjlbkHupWHFVUQXFgTEj.text = qNACakqVLwsRRIoGiuTfCYOPEIZ;
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			if (YGyTLoahjIowSAHmDSFheJNtEkf && _useUnityUI != hhUDovGYiTdZTzpHnTnpcwjLQJQ)
			{
				hhUDovGYiTdZTzpHnTnpcwjLQJQ = _useUnityUI;
				if (_useUnityUI)
				{
					MOeEtPKqljQfLiTIUkByBLzgiAgj();
				}
				else
				{
					FkOEupbyOvRnDimEZuYHkBscttVr();
				}
			}
		}

		private void MOeEtPKqljQfLiTIUkByBLzgiAgj()
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
			bSDJlLPPjlbkHupWHFVUQXFgTEj = GetComponent<Text>();
			if (bSDJlLPPjlbkHupWHFVUQXFgTEj == null)
			{
				RectTransform rectTransform = base.gameObject.AddComponent<RectTransform>();
				rectTransform.anchorMax = new Vector2(1f, 1f);
				rectTransform.anchorMin = new Vector2(0f, 0f);
				rectTransform.localPosition = Vector2.zero;
				rectTransform.anchoredPosition = Vector2.zero;
				rectTransform.sizeDelta = Vector3.zero;
				bSDJlLPPjlbkHupWHFVUQXFgTEj = base.gameObject.AddComponent<Text>();
				bSDJlLPPjlbkHupWHFVUQXFgTEj.color = Color.white;
				bSDJlLPPjlbkHupWHFVUQXFgTEj.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
				bSDJlLPPjlbkHupWHFVUQXFgTEj.fontSize = 13;
				if (IyuxgophNwGFnfQEIHtLFUgVfzHn)
				{
					bSDJlLPPjlbkHupWHFVUQXFgTEj.alignment = bzhqpOlBFEefeawqUGaluDPKGStb;
				}
				else
				{
					bzhqpOlBFEefeawqUGaluDPKGStb = bSDJlLPPjlbkHupWHFVUQXFgTEj.alignment;
				}
				if (TNBAHqebOPXzFvfXRRnBHsjDYnQ)
				{
					bSDJlLPPjlbkHupWHFVUQXFgTEj.font = eAyzjMdoFhEYEgmoRRHTIDiOcAo;
				}
				else
				{
					eAyzjMdoFhEYEgmoRRHTIDiOcAo = bSDJlLPPjlbkHupWHFVUQXFgTEj.font;
				}
				if (RnDgBKcVzgpzRhKwHAwjfOTRNMP)
				{
					bSDJlLPPjlbkHupWHFVUQXFgTEj.fontSize = KttadTQIzcEmXXqmiPbCyEBEzFL;
				}
				else
				{
					KttadTQIzcEmXXqmiPbCyEBEzFL = bSDJlLPPjlbkHupWHFVUQXFgTEj.fontSize;
				}
				if (FjvDvZCZYEQvbRGbCpvxhVcJgqxj)
				{
					bSDJlLPPjlbkHupWHFVUQXFgTEj.fontStyle = EyXftxEfJbzQycDqoTKSHaiXQlcH;
				}
				else
				{
					EyXftxEfJbzQycDqoTKSHaiXQlcH = bSDJlLPPjlbkHupWHFVUQXFgTEj.fontStyle;
				}
				if (XTPauChYTxPgJFaNsXGnctYfUCH)
				{
					bSDJlLPPjlbkHupWHFVUQXFgTEj.color = AEbNHMhmDGIdFPgkerpPWiidIux;
				}
				else
				{
					AEbNHMhmDGIdFPgkerpPWiidIux = bSDJlLPPjlbkHupWHFVUQXFgTEj.color;
				}
			}
		}

		private void FkOEupbyOvRnDimEZuYHkBscttVr()
		{
			if (Application.isPlaying)
			{
				if (bSDJlLPPjlbkHupWHFVUQXFgTEj != null)
				{
					bSDJlLPPjlbkHupWHFVUQXFgTEj.text = string.Empty;
				}
				bSDJlLPPjlbkHupWHFVUQXFgTEj = null;
			}
		}

		private void dKZDSEbVdyNsYtqGieYUSKJTlLk()
		{
			ZbuUbQDFZThIYMMoRKiVNMWlfRP = new GUIStyle(GUI.skin.label);
			if (IyuxgophNwGFnfQEIHtLFUgVfzHn)
			{
				ZbuUbQDFZThIYMMoRKiVNMWlfRP.alignment = bzhqpOlBFEefeawqUGaluDPKGStb;
			}
			else
			{
				bzhqpOlBFEefeawqUGaluDPKGStb = ZbuUbQDFZThIYMMoRKiVNMWlfRP.alignment;
			}
			if (TNBAHqebOPXzFvfXRRnBHsjDYnQ)
			{
				ZbuUbQDFZThIYMMoRKiVNMWlfRP.font = eAyzjMdoFhEYEgmoRRHTIDiOcAo;
			}
			else
			{
				eAyzjMdoFhEYEgmoRRHTIDiOcAo = ZbuUbQDFZThIYMMoRKiVNMWlfRP.font;
			}
			if (RnDgBKcVzgpzRhKwHAwjfOTRNMP)
			{
				ZbuUbQDFZThIYMMoRKiVNMWlfRP.fontSize = KttadTQIzcEmXXqmiPbCyEBEzFL;
			}
			else
			{
				KttadTQIzcEmXXqmiPbCyEBEzFL = ZbuUbQDFZThIYMMoRKiVNMWlfRP.fontSize;
			}
			if (FjvDvZCZYEQvbRGbCpvxhVcJgqxj)
			{
				ZbuUbQDFZThIYMMoRKiVNMWlfRP.fontStyle = EyXftxEfJbzQycDqoTKSHaiXQlcH;
			}
			else
			{
				EyXftxEfJbzQycDqoTKSHaiXQlcH = ZbuUbQDFZThIYMMoRKiVNMWlfRP.fontStyle;
			}
			if (XTPauChYTxPgJFaNsXGnctYfUCH)
			{
				ZbuUbQDFZThIYMMoRKiVNMWlfRP.normal.textColor = AEbNHMhmDGIdFPgkerpPWiidIux;
			}
			else
			{
				AEbNHMhmDGIdFPgkerpPWiidIux = ZbuUbQDFZThIYMMoRKiVNMWlfRP.normal.textColor;
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
