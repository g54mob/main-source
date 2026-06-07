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
		private string OahRefBqcJEyTlhmdSTeJJPoPlS;

		private GUIStyle pHRuGwuwauCCAvJqIlSpUfHIyQI;

		private TextAnchor FmEnaJEQcnfKucVSZMumblQbbdoD;

		private TextAlignment GPPgpZBMMwDpRWTKdoDdyayqstn;

		private float QvfUvCFKhSeEgMOiQcqCzvoYMcU;

		private Font IFFXtPEuJSozQTOUGqDCPOKhNTz;

		private int wsQrdWtASTZVZsJQxlbBxOMfuaU = -1;

		private FontStyle afydMmIyWQzXaoQelUVJxfxcEqf;

		private Color yWCYLVOjDdbhPaiUbqlCZzxAmRe = Color.white;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Vector2 _pixelOffset;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useUnityUI;

		private bool akXldzKIaFqwpExuDsrIZCdumYK;

		private bool RrjCasFnhlStOurlNekEbVIbSmlN;

		private bool BnYJelBqDVPTtVivwpbLmNttHXh;

		private bool xSiBIrFVrgOuFdUfEUZCgYoeyjT;

		private bool hTgBgRagWTCwXKhAEkRaDkOefdA;

		private bool hQSpREwvnfOmbnZtHvKsahMwZfg;

		private bool rjwgmZWLpKDmLHedduHepvLQTtSS;

		private Text XrgtmKaMMSLKLPmkITeZTWUFtHq;

		private bool TgtORefCDuRYRGfdoFvijcqoGpH;

		private bool obRcVdGXYvPPOEdtEYYsLbSAKxqw;

		public string text
		{
			get
			{
				return OahRefBqcJEyTlhmdSTeJJPoPlS;
			}
			set
			{
				OahRefBqcJEyTlhmdSTeJJPoPlS = value;
			}
		}

		public TextAnchor anchor
		{
			get
			{
				return FmEnaJEQcnfKucVSZMumblQbbdoD;
			}
			set
			{
				FmEnaJEQcnfKucVSZMumblQbbdoD = value;
				akXldzKIaFqwpExuDsrIZCdumYK = true;
				while (true)
				{
					int num = 922534470;
					while (true)
					{
						switch (num ^ 0x36FCC245)
						{
						case 0:
							break;
						default:
							return;
						case 3:
							if (pHRuGwuwauCCAvJqIlSpUfHIyQI != null)
							{
								goto IL_0040;
							}
							return;
						case 2:
							goto IL_0040;
						case 1:
							return;
						}
						break;
						IL_0040:
						pHRuGwuwauCCAvJqIlSpUfHIyQI.alignment = value;
						num = 922534468;
					}
				}
			}
		}

		public TextAlignment alignment
		{
			get
			{
				return GPPgpZBMMwDpRWTKdoDdyayqstn;
			}
			set
			{
				GPPgpZBMMwDpRWTKdoDdyayqstn = value;
				RrjCasFnhlStOurlNekEbVIbSmlN = true;
			}
		}

		public float lineSpacing
		{
			get
			{
				return QvfUvCFKhSeEgMOiQcqCzvoYMcU;
			}
			set
			{
				QvfUvCFKhSeEgMOiQcqCzvoYMcU = value;
				BnYJelBqDVPTtVivwpbLmNttHXh = true;
				GUIStyle pHRuGwuwauCCAvJqIlSpUfHIyQI2 = pHRuGwuwauCCAvJqIlSpUfHIyQI;
			}
		}

		public Font font
		{
			get
			{
				return IFFXtPEuJSozQTOUGqDCPOKhNTz;
			}
			set
			{
				xSiBIrFVrgOuFdUfEUZCgYoeyjT = true;
				IFFXtPEuJSozQTOUGqDCPOKhNTz = value;
				if (pHRuGwuwauCCAvJqIlSpUfHIyQI != null)
				{
					pHRuGwuwauCCAvJqIlSpUfHIyQI.font = value;
				}
			}
		}

		public int fontSize
		{
			get
			{
				return wsQrdWtASTZVZsJQxlbBxOMfuaU;
			}
			set
			{
				wsQrdWtASTZVZsJQxlbBxOMfuaU = value;
				while (true)
				{
					int num = -1070769813;
					while (true)
					{
						switch (num ^ -1070769815)
						{
						case 4:
							break;
						default:
							return;
						case 0:
							pHRuGwuwauCCAvJqIlSpUfHIyQI.fontSize = value;
							num = -1070769814;
							continue;
						case 1:
							return;
						case 2:
						{
							hTgBgRagWTCwXKhAEkRaDkOefdA = true;
							int num2;
							if (pHRuGwuwauCCAvJqIlSpUfHIyQI != null)
							{
								num = -1070769815;
								num2 = num;
							}
							else
							{
								num = -1070769816;
								num2 = num;
							}
							continue;
						}
						case 3:
							return;
						}
						break;
					}
				}
			}
		}

		public FontStyle fontStyle
		{
			get
			{
				return afydMmIyWQzXaoQelUVJxfxcEqf;
			}
			set
			{
				afydMmIyWQzXaoQelUVJxfxcEqf = value;
				hQSpREwvnfOmbnZtHvKsahMwZfg = true;
				while (true)
				{
					switch (0x1DE99B24 ^ 0x1DE99B25)
					{
					case 0:
						continue;
					case 1:
						if (pHRuGwuwauCCAvJqIlSpUfHIyQI == null)
						{
							return;
						}
						break;
					}
					break;
				}
				pHRuGwuwauCCAvJqIlSpUfHIyQI.fontStyle = value;
			}
		}

		public Color color
		{
			get
			{
				return yWCYLVOjDdbhPaiUbqlCZzxAmRe;
			}
			set
			{
				yWCYLVOjDdbhPaiUbqlCZzxAmRe = value;
				rjwgmZWLpKDmLHedduHepvLQTtSS = true;
				if (pHRuGwuwauCCAvJqIlSpUfHIyQI != null)
				{
					pHRuGwuwauCCAvJqIlSpUfHIyQI.normal.textColor = value;
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
				if (_useUnityUI == value)
				{
					goto IL_0009;
				}
				goto IL_0053;
				IL_0009:
				int num = -1519206235;
				goto IL_000e;
				IL_000e:
				while (true)
				{
					switch (num ^ -1519206239)
					{
					case 0:
						break;
					default:
						return;
					case 4:
						return;
					case 5:
						TgtORefCDuRYRGfdoFvijcqoGpH = value;
						if (value)
						{
							klVftETMuWSfLyiTZTEzQqkVhrp();
							return;
						}
						goto case 1;
					case 3:
						goto IL_0053;
					case 1:
						jvvylaNgbEKlHTesSGfAGvrVCSA();
						num = -1519206237;
						continue;
					case 2:
						return;
					}
					break;
				}
				goto IL_0009;
				IL_0053:
				_useUnityUI = value;
				num = -1519206236;
				goto IL_000e;
			}
		}

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			obRcVdGXYvPPOEdtEYYsLbSAKxqw = true;
		}

		[CustomObfuscation(rename = false)]
		private void Start()
		{
			TgtORefCDuRYRGfdoFvijcqoGpH = _useUnityUI;
			if (!_useUnityUI)
			{
				return;
			}
			while (true)
			{
				int num = 951015903;
				while (true)
				{
					switch (num ^ 0x38AF59DD)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_0032;
					case 1:
						return;
					}
					break;
					IL_0032:
					klVftETMuWSfLyiTZTEzQqkVhrp();
					num = 951015900;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			if (_useUnityUI)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (pHRuGwuwauCCAvJqIlSpUfHIyQI == null)
				{
					num = 1659420987;
					num2 = num;
				}
				else
				{
					num = 1659420986;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x62E8C138)
					{
					case 0:
						num = 1659420988;
						continue;
					default:
						return;
					case 4:
						break;
					case 2:
						if (!string.IsNullOrEmpty(OahRefBqcJEyTlhmdSTeJJPoPlS))
						{
							Vector2 vector = base.transform.localPosition;
							Rect position = new Rect(vector.x * (float)Screen.width + _pixelOffset.x, vector.y * (float)Screen.height + _pixelOffset.y, MathTools.Clamp((float)Screen.width - vector.x * (float)Screen.width, 0f, float.MaxValue), MathTools.Clamp((float)Screen.height - vector.y * (float)Screen.height, 0f, float.MaxValue));
							GUI.Label(position, OahRefBqcJEyTlhmdSTeJJPoPlS, pHRuGwuwauCCAvJqIlSpUfHIyQI);
							num = 1659420985;
							continue;
						}
						return;
					case 3:
						LYoUuVIeQVLIWSIcpMpBHaWakzj();
						num = 1659420986;
						continue;
					case 1:
						return;
					}
					break;
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
			RectTransform component = default(RectTransform);
			while (true)
			{
				IL_007e:
				int num;
				if (XrgtmKaMMSLKLPmkITeZTWUFtHq == null)
				{
					Logger.LogError("Text component has been deleted.");
					num = -692499530;
					goto IL_000e;
				}
				goto IL_0033;
				IL_000e:
				while (true)
				{
					switch (num ^ -692499530)
					{
					case 2:
						num = -692499534;
						continue;
					case 3:
						break;
					case 0:
						return;
					case 5:
						component.anchoredPosition = _pixelOffset;
						num = -692499529;
						continue;
					case 4:
						goto IL_007e;
					default:
						XrgtmKaMMSLKLPmkITeZTWUFtHq.text = OahRefBqcJEyTlhmdSTeJJPoPlS;
						return;
					}
					break;
				}
				goto IL_0033;
				IL_0033:
				component = XrgtmKaMMSLKLPmkITeZTWUFtHq.GetComponent<RectTransform>();
				int num2;
				if (component.anchoredPosition != _pixelOffset)
				{
					num = -692499533;
					num2 = num;
				}
				else
				{
					num = -692499529;
					num2 = num;
				}
				goto IL_000e;
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			if (!obRcVdGXYvPPOEdtEYYsLbSAKxqw)
			{
				return;
			}
			while (_useUnityUI != TgtORefCDuRYRGfdoFvijcqoGpH)
			{
				TgtORefCDuRYRGfdoFvijcqoGpH = _useUnityUI;
				int num = 860022569;
				while (true)
				{
					switch (num ^ 0x3342E72D)
					{
					case 0:
						num = 860022572;
						continue;
					default:
						return;
					case 2:
						klVftETMuWSfLyiTZTEzQqkVhrp();
						return;
					case 5:
						jvvylaNgbEKlHTesSGfAGvrVCSA();
						num = 860022574;
						continue;
					case 1:
						break;
					case 4:
					{
						int num2;
						if (!_useUnityUI)
						{
							num = 860022568;
							num2 = num;
						}
						else
						{
							num = 860022575;
							num2 = num;
						}
						continue;
					}
					case 3:
						return;
					}
					break;
				}
			}
		}

		private void klVftETMuWSfLyiTZTEzQqkVhrp()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			GameObject gameObject = default(GameObject);
			while (true)
			{
				Canvas componentInSelfOrParents = UnityTools.GetComponentInSelfOrParents<Canvas>(base.transform);
				int num;
				int num2;
				if (componentInSelfOrParents == null)
				{
					num = 616805624;
					num2 = num;
				}
				else
				{
					num = 616805616;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x24C3B4F7)
					{
					case 18:
						num = 616805600;
						continue;
					default:
						return;
					case 26:
						IFFXtPEuJSozQTOUGqDCPOKhNTz = XrgtmKaMMSLKLPmkITeZTWUFtHq.font;
						num = 616805602;
						continue;
					case 9:
						if (akXldzKIaFqwpExuDsrIZCdumYK)
						{
							XrgtmKaMMSLKLPmkITeZTWUFtHq.alignment = FmEnaJEQcnfKucVSZMumblQbbdoD;
							num = 616805622;
							continue;
						}
						goto case 10;
					case 7:
						XrgtmKaMMSLKLPmkITeZTWUFtHq = GetComponent<Text>();
						num = 616805621;
						continue;
					case 22:
						afydMmIyWQzXaoQelUVJxfxcEqf = XrgtmKaMMSLKLPmkITeZTWUFtHq.fontStyle;
						num = 616805625;
						continue;
					case 20:
						yWCYLVOjDdbhPaiUbqlCZzxAmRe = XrgtmKaMMSLKLPmkITeZTWUFtHq.color;
						num = 616805626;
						continue;
					case 24:
						XrgtmKaMMSLKLPmkITeZTWUFtHq.color = Color.white;
						num = 616805618;
						continue;
					case 5:
						XrgtmKaMMSLKLPmkITeZTWUFtHq.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
						XrgtmKaMMSLKLPmkITeZTWUFtHq.fontSize = 13;
						num = 616805630;
						continue;
					case 2:
						if (XrgtmKaMMSLKLPmkITeZTWUFtHq == null)
						{
							RectTransform rectTransform = base.gameObject.AddComponent<RectTransform>();
							rectTransform.anchorMax = new Vector2(1f, 1f);
							rectTransform.anchorMin = new Vector2(0f, 0f);
							rectTransform.localPosition = Vector2.zero;
							rectTransform.anchoredPosition = Vector2.zero;
							rectTransform.sizeDelta = Vector3.zero;
							XrgtmKaMMSLKLPmkITeZTWUFtHq = base.gameObject.AddComponent<Text>();
							num = 616805615;
							continue;
						}
						return;
					case 19:
						gameObject.GetComponent<CanvasScaler>();
						num = 616805616;
						continue;
					case 1:
						if (xSiBIrFVrgOuFdUfEUZCgYoeyjT)
						{
							XrgtmKaMMSLKLPmkITeZTWUFtHq.font = IFFXtPEuJSozQTOUGqDCPOKhNTz;
							num = 616805602;
							continue;
						}
						goto case 26;
					case 17:
						XrgtmKaMMSLKLPmkITeZTWUFtHq.fontStyle = afydMmIyWQzXaoQelUVJxfxcEqf;
						num = 616805625;
						continue;
					case 11:
						XrgtmKaMMSLKLPmkITeZTWUFtHq.color = yWCYLVOjDdbhPaiUbqlCZzxAmRe;
						return;
					case 21:
					{
						int num6;
						if (!hTgBgRagWTCwXKhAEkRaDkOefdA)
						{
							num = 616805620;
							num6 = num;
						}
						else
						{
							num = 616805617;
							num6 = num;
						}
						continue;
					}
					case 16:
						gameObject.AddComponent<CanvasScaler>();
						num = 616805631;
						continue;
					case 14:
					{
						int num5;
						if (!rjwgmZWLpKDmLHedduHepvLQTtSS)
						{
							num = 616805603;
							num5 = num;
						}
						else
						{
							num = 616805628;
							num5 = num;
						}
						continue;
					}
					case 8:
						num = 616805616;
						continue;
					case 10:
						FmEnaJEQcnfKucVSZMumblQbbdoD = XrgtmKaMMSLKLPmkITeZTWUFtHq.alignment;
						num = 616805622;
						continue;
					case 15:
						if (base.transform.root == base.transform)
						{
							gameObject = new GameObject("Canvas");
							num = 616805627;
							continue;
						}
						goto case 25;
					case 25:
						gameObject = base.transform.root.gameObject;
						num = 616805619;
						continue;
					case 23:
						break;
					case 4:
					{
						componentInSelfOrParents = gameObject.AddComponent<Canvas>();
						componentInSelfOrParents.renderMode = RenderMode.ScreenSpaceOverlay;
						int num4;
						if (!(gameObject.GetComponent<CanvasScaler>() != null))
						{
							num = 616805607;
							num4 = num;
						}
						else
						{
							num = 616805604;
							num4 = num;
						}
						continue;
					}
					case 3:
						wsQrdWtASTZVZsJQxlbBxOMfuaU = XrgtmKaMMSLKLPmkITeZTWUFtHq.fontSize;
						num = 616805623;
						continue;
					case 6:
						XrgtmKaMMSLKLPmkITeZTWUFtHq.fontSize = wsQrdWtASTZVZsJQxlbBxOMfuaU;
						num = 616805623;
						continue;
					case 0:
					{
						int num3;
						if (!hQSpREwvnfOmbnZtHvKsahMwZfg)
						{
							num = 616805601;
							num3 = num;
						}
						else
						{
							num = 616805606;
							num3 = num;
						}
						continue;
					}
					case 12:
						base.transform.SetParent(gameObject.transform, true);
						num = 616805619;
						continue;
					case 13:
						return;
					}
					break;
				}
			}
		}

		private void jvvylaNgbEKlHTesSGfAGvrVCSA()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (!(XrgtmKaMMSLKLPmkITeZTWUFtHq != null))
				{
					num = -952538912;
					num2 = num;
				}
				else
				{
					num = -952538911;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -952538911)
					{
					case 2:
						num = -952538910;
						continue;
					case 3:
						break;
					case 0:
						XrgtmKaMMSLKLPmkITeZTWUFtHq.text = string.Empty;
						num = -952538912;
						continue;
					default:
						XrgtmKaMMSLKLPmkITeZTWUFtHq = null;
						return;
					}
					break;
				}
			}
		}

		private void LYoUuVIeQVLIWSIcpMpBHaWakzj()
		{
			pHRuGwuwauCCAvJqIlSpUfHIyQI = new GUIStyle(GUI.skin.label);
			while (true)
			{
				int num = -1043830665;
				while (true)
				{
					switch (num ^ -1043830671)
					{
					case 8:
						break;
					case 6:
						if (akXldzKIaFqwpExuDsrIZCdumYK)
						{
							pHRuGwuwauCCAvJqIlSpUfHIyQI.alignment = FmEnaJEQcnfKucVSZMumblQbbdoD;
							num = -1043830662;
							continue;
						}
						goto case 0;
					case 9:
						if (xSiBIrFVrgOuFdUfEUZCgYoeyjT)
						{
							pHRuGwuwauCCAvJqIlSpUfHIyQI.font = IFFXtPEuJSozQTOUGqDCPOKhNTz;
							num = -1043830668;
							continue;
						}
						goto case 4;
					case 5:
						if (hTgBgRagWTCwXKhAEkRaDkOefdA)
						{
							pHRuGwuwauCCAvJqIlSpUfHIyQI.fontSize = wsQrdWtASTZVZsJQxlbBxOMfuaU;
							num = -1043830670;
							continue;
						}
						goto case 10;
					case 4:
						IFFXtPEuJSozQTOUGqDCPOKhNTz = pHRuGwuwauCCAvJqIlSpUfHIyQI.font;
						num = -1043830668;
						continue;
					case 1:
						afydMmIyWQzXaoQelUVJxfxcEqf = pHRuGwuwauCCAvJqIlSpUfHIyQI.fontStyle;
						num = -1043830669;
						continue;
					case 3:
						if (hQSpREwvnfOmbnZtHvKsahMwZfg)
						{
							pHRuGwuwauCCAvJqIlSpUfHIyQI.fontStyle = afydMmIyWQzXaoQelUVJxfxcEqf;
							num = -1043830669;
							continue;
						}
						goto case 1;
					case 10:
						wsQrdWtASTZVZsJQxlbBxOMfuaU = pHRuGwuwauCCAvJqIlSpUfHIyQI.fontSize;
						num = -1043830670;
						continue;
					case 11:
						num = -1043830664;
						continue;
					case 2:
						if (rjwgmZWLpKDmLHedduHepvLQTtSS)
						{
							pHRuGwuwauCCAvJqIlSpUfHIyQI.normal.textColor = yWCYLVOjDdbhPaiUbqlCZzxAmRe;
							return;
						}
						goto default;
					case 0:
						FmEnaJEQcnfKucVSZMumblQbbdoD = pHRuGwuwauCCAvJqIlSpUfHIyQI.alignment;
						num = -1043830664;
						continue;
					default:
						yWCYLVOjDdbhPaiUbqlCZzxAmRe = pHRuGwuwauCCAvJqIlSpUfHIyQI.normal.textColor;
						return;
					}
					break;
				}
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
