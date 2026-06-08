using System.ComponentModel;
using Rewired.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.Internal
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	[AddComponentMenu("")]
	[Browsable(false)]
	public class GUIText : MonoBehaviour
	{
		private string EMbSevZdJPCAzilOEFqxJghbenkC;

		private GUIStyle bdRuCsmbBycMukFQpvnghGpVGKs;

		private TextAnchor LYUUCNQWPbqnACMmeTehIyqanRO;

		private TextAlignment ArFsEVJFjmFlpeVyANVaETMCnqJX;

		private float WJrYcCZSCWcQWHDOrKNFAEWDROkG;

		private Font UARPaRMnyQRCkKnujsKVimqkHuH;

		private int yRMLrOdRnRtfrbUqACmYWAoqedy = -1;

		private FontStyle oXkXXsMHFSiBGlseUEnWOILzeCX;

		private Color aEIfrTEAytBkjhfuOMMTylHLHzW = Color.white;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Vector2 _pixelOffset;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _useUnityUI;

		private bool wWZZzxMbLVAENXvUkCNRyMNzUmy;

		private bool JlnEeFzEjPVaCbFcqZXacksxeFR;

		private bool RxIAIzPPaNpdDUOPRbYMdNHkMLFt;

		private bool hMmcbpXCkaEfHBTexyZnlMbndjr;

		private bool pLcZxVwPpPPsfLYcbABnmZqnAdm;

		private bool pIOWRYwVGxMsXcYvwJUvZJNhWJE;

		private bool xTgWlRGCEYGQjfhNKIonAtpNDjgk;

		private Text RScqPMstlAuftSCCzVaWqpmAxtK;

		private bool FFpbecnTeweuhBcBTqlxESTdjbx;

		private bool yTGtzNsrhQtmquZvppvWfgPwvQ;

		public string text
		{
			get
			{
				return EMbSevZdJPCAzilOEFqxJghbenkC;
			}
			set
			{
				EMbSevZdJPCAzilOEFqxJghbenkC = value;
			}
		}

		public TextAnchor anchor
		{
			get
			{
				return LYUUCNQWPbqnACMmeTehIyqanRO;
			}
			set
			{
				LYUUCNQWPbqnACMmeTehIyqanRO = value;
				wWZZzxMbLVAENXvUkCNRyMNzUmy = true;
				if (bdRuCsmbBycMukFQpvnghGpVGKs != null)
				{
					bdRuCsmbBycMukFQpvnghGpVGKs.alignment = value;
				}
			}
		}

		public TextAlignment alignment
		{
			get
			{
				return ArFsEVJFjmFlpeVyANVaETMCnqJX;
			}
			set
			{
				ArFsEVJFjmFlpeVyANVaETMCnqJX = value;
				JlnEeFzEjPVaCbFcqZXacksxeFR = true;
			}
		}

		public float lineSpacing
		{
			get
			{
				return WJrYcCZSCWcQWHDOrKNFAEWDROkG;
			}
			set
			{
				WJrYcCZSCWcQWHDOrKNFAEWDROkG = value;
				RxIAIzPPaNpdDUOPRbYMdNHkMLFt = true;
				_ = bdRuCsmbBycMukFQpvnghGpVGKs;
			}
		}

		public Font font
		{
			get
			{
				return UARPaRMnyQRCkKnujsKVimqkHuH;
			}
			set
			{
				hMmcbpXCkaEfHBTexyZnlMbndjr = true;
				UARPaRMnyQRCkKnujsKVimqkHuH = value;
				if (bdRuCsmbBycMukFQpvnghGpVGKs == null)
				{
					while (true)
					{
						switch (0x18E8F04E ^ 0x18E8F04F)
						{
						case 0:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				bdRuCsmbBycMukFQpvnghGpVGKs.font = value;
			}
		}

		public int fontSize
		{
			get
			{
				return yRMLrOdRnRtfrbUqACmYWAoqedy;
			}
			set
			{
				yRMLrOdRnRtfrbUqACmYWAoqedy = value;
				pLcZxVwPpPPsfLYcbABnmZqnAdm = true;
				if (bdRuCsmbBycMukFQpvnghGpVGKs != null)
				{
					bdRuCsmbBycMukFQpvnghGpVGKs.fontSize = value;
				}
			}
		}

		public FontStyle fontStyle
		{
			get
			{
				return oXkXXsMHFSiBGlseUEnWOILzeCX;
			}
			set
			{
				oXkXXsMHFSiBGlseUEnWOILzeCX = value;
				pIOWRYwVGxMsXcYvwJUvZJNhWJE = true;
				while (true)
				{
					int num = -157713598;
					while (true)
					{
						switch (num ^ -157713597)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							if (bdRuCsmbBycMukFQpvnghGpVGKs != null)
							{
								goto IL_0040;
							}
							return;
						case 3:
							goto IL_0040;
						case 0:
							return;
						}
						break;
						IL_0040:
						bdRuCsmbBycMukFQpvnghGpVGKs.fontStyle = value;
						num = -157713597;
					}
				}
			}
		}

		public Color color
		{
			get
			{
				return aEIfrTEAytBkjhfuOMMTylHLHzW;
			}
			set
			{
				aEIfrTEAytBkjhfuOMMTylHLHzW = value;
				while (true)
				{
					int num = 177816602;
					while (true)
					{
						switch (num ^ 0xA994418)
						{
						case 0:
							break;
						case 2:
							goto IL_0029;
						case 3:
							if (bdRuCsmbBycMukFQpvnghGpVGKs == null)
							{
								return;
							}
							goto default;
						default:
							bdRuCsmbBycMukFQpvnghGpVGKs.normal.textColor = value;
							return;
						}
						break;
						IL_0029:
						xTgWlRGCEYGQjfhNKIonAtpNDjgk = true;
						num = 177816603;
					}
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
					return;
				}
				while (true)
				{
					_useUnityUI = value;
					int num = 1419654695;
					while (true)
					{
						switch (num ^ 0x549E3622)
						{
						case 3:
							num = 1419654694;
							continue;
						default:
							return;
						case 4:
							break;
						case 1:
							return;
						case 7:
							fktyQwVxYAnidGQIpbfXGjHGmKoA();
							num = 1419654692;
							continue;
						case 0:
						{
							int num2;
							if (value)
							{
								num = 1419654688;
								num2 = num;
							}
							else
							{
								num = 1419654693;
								num2 = num;
							}
							continue;
						}
						case 2:
							knNwRMHYtWBqfpOCszgyxeYYAzPf();
							num = 1419654691;
							continue;
						case 5:
							FFpbecnTeweuhBcBTqlxESTdjbx = value;
							num = 1419654690;
							continue;
						case 6:
							return;
						}
						break;
					}
				}
			}
		}

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			yTGtzNsrhQtmquZvppvWfgPwvQ = true;
		}

		[CustomObfuscation(rename = false)]
		private void Start()
		{
			FFpbecnTeweuhBcBTqlxESTdjbx = _useUnityUI;
			if (_useUnityUI)
			{
				knNwRMHYtWBqfpOCszgyxeYYAzPf();
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			if (_useUnityUI)
			{
				goto IL_0008;
			}
			goto IL_0039;
			IL_0008:
			int num = 827235108;
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x314E9B27)
			{
			case 0:
				break;
			default:
				return;
			case 3:
				return;
			case 4:
				goto IL_0039;
			case 2:
				goto IL_004e;
			case 1:
				return;
			}
			goto IL_0008;
			IL_0039:
			if (bdRuCsmbBycMukFQpvnghGpVGKs == null)
			{
				FmgLuFMehDTdyRLUIKbAuEmhouB();
				num = 827235109;
				goto IL_000d;
			}
			goto IL_004e;
			IL_004e:
			if (!string.IsNullOrEmpty(EMbSevZdJPCAzilOEFqxJghbenkC))
			{
				Vector2 vector = base.transform.localPosition;
				Rect position = new Rect(vector.x * (float)Screen.width + _pixelOffset.x, vector.y * (float)Screen.height + _pixelOffset.y, MathTools.Clamp((float)Screen.width - vector.x * (float)Screen.width, 0f, float.MaxValue), MathTools.Clamp((float)Screen.height - vector.y * (float)Screen.height, 0f, float.MaxValue));
				GUI.Label(position, EMbSevZdJPCAzilOEFqxJghbenkC, bdRuCsmbBycMukFQpvnghGpVGKs);
				num = 827235110;
				goto IL_000d;
			}
		}

		[CustomObfuscation(rename = false)]
		private void Update()
		{
			if (!_useUnityUI)
			{
				return;
			}
			while (!(RScqPMstlAuftSCCzVaWqpmAxtK == null))
			{
				while (true)
				{
					RectTransform component = RScqPMstlAuftSCCzVaWqpmAxtK.GetComponent<RectTransform>();
					int num = 1102396241;
					while (true)
					{
						switch (num ^ 0x41B53B51)
						{
						case 3:
							num = 1102396243;
							continue;
						default:
							return;
						case 0:
							break;
						case 5:
							goto end_IL_0011;
						case 1:
							RScqPMstlAuftSCCzVaWqpmAxtK.text = EMbSevZdJPCAzilOEFqxJghbenkC;
							num = 1102396245;
							continue;
						case 2:
							goto end_IL_0061;
						case 6:
							component.anchoredPosition = _pixelOffset;
							num = 1102396240;
							continue;
						case 4:
							return;
						}
						int num2;
						if (!(component.anchoredPosition != _pixelOffset))
						{
							num = 1102396240;
							num2 = num;
						}
						else
						{
							num = 1102396247;
							num2 = num;
						}
						continue;
						end_IL_0011:
						break;
					}
					continue;
					end_IL_0061:
					break;
				}
			}
			Logger.LogError("Text component has been deleted.");
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			if (!yTGtzNsrhQtmquZvppvWfgPwvQ)
			{
				return;
			}
			while (_useUnityUI != FFpbecnTeweuhBcBTqlxESTdjbx)
			{
				FFpbecnTeweuhBcBTqlxESTdjbx = _useUnityUI;
				int num = -364500254;
				while (true)
				{
					switch (num ^ -364500249)
					{
					case 0:
						num = -364500250;
						continue;
					default:
						return;
					case 3:
						fktyQwVxYAnidGQIpbfXGjHGmKoA();
						num = -364500251;
						continue;
					case 4:
						return;
					case 5:
						if (_useUnityUI)
						{
							knNwRMHYtWBqfpOCszgyxeYYAzPf();
							num = -364500253;
							continue;
						}
						goto case 3;
					case 1:
						break;
					case 2:
						return;
					}
					break;
				}
			}
		}

		private void knNwRMHYtWBqfpOCszgyxeYYAzPf()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			GameObject gameObject = default(GameObject);
			RectTransform rectTransform = default(RectTransform);
			while (true)
			{
				IL_0270:
				Canvas componentInSelfOrParents = UnityTools.GetComponentInSelfOrParents<Canvas>(base.transform);
				if (!(componentInSelfOrParents == null))
				{
					goto IL_00aa;
				}
				int num;
				if (base.transform.root == base.transform)
				{
					gameObject = new GameObject("Canvas");
					base.transform.SetParent(gameObject.transform, worldPositionStays: true);
					num = 257294327;
					goto IL_0010;
				}
				goto IL_00f2;
				IL_00f2:
				gameObject = base.transform.root.gameObject;
				num = 257294314;
				goto IL_0010;
				IL_0010:
				while (true)
				{
					switch (num ^ 0xF55FFE1)
					{
					case 23:
						num = 257294321;
						continue;
					default:
						return;
					case 21:
						break;
					case 15:
						num = 257294312;
						continue;
					case 5:
						goto end_IL_0010;
					case 4:
						goto IL_00f2;
					case 3:
						RScqPMstlAuftSCCzVaWqpmAxtK.alignment = LYUUCNQWPbqnACMmeTehIyqanRO;
						num = 257294323;
						continue;
					case 7:
						oXkXXsMHFSiBGlseUEnWOILzeCX = RScqPMstlAuftSCCzVaWqpmAxtK.fontStyle;
						num = 257294312;
						continue;
					case 13:
						gameObject.GetComponent<CanvasScaler>();
						num = 257294308;
						continue;
					case 17:
						goto IL_0154;
					case 14:
						if (pLcZxVwPpPPsfLYcbABnmZqnAdm)
						{
							RScqPMstlAuftSCCzVaWqpmAxtK.fontSize = yRMLrOdRnRtfrbUqACmYWAoqedy;
							num = 257294311;
							continue;
						}
						goto case 24;
					case 24:
						yRMLrOdRnRtfrbUqACmYWAoqedy = RScqPMstlAuftSCCzVaWqpmAxtK.fontSize;
						num = 257294311;
						continue;
					case 1:
						UARPaRMnyQRCkKnujsKVimqkHuH = RScqPMstlAuftSCCzVaWqpmAxtK.font;
						num = 257294319;
						continue;
					case 12:
						rectTransform.anchorMin = new Vector2(0f, 0f);
						num = 257294305;
						continue;
					case 20:
						aEIfrTEAytBkjhfuOMMTylHLHzW = RScqPMstlAuftSCCzVaWqpmAxtK.color;
						num = 257294315;
						continue;
					case 8:
						return;
					case 19:
						RScqPMstlAuftSCCzVaWqpmAxtK.font = UARPaRMnyQRCkKnujsKVimqkHuH;
						num = 257294319;
						continue;
					case 11:
						componentInSelfOrParents = gameObject.AddComponent<Canvas>();
						componentInSelfOrParents.renderMode = RenderMode.ScreenSpaceOverlay;
						if (!(gameObject.GetComponent<CanvasScaler>() != null))
						{
							gameObject.AddComponent<CanvasScaler>();
							num = 257294308;
							continue;
						}
						goto case 13;
					case 18:
						num = 257294324;
						continue;
					case 16:
						goto IL_0270;
					case 0:
						rectTransform.localPosition = Vector2.zero;
						rectTransform.anchoredPosition = Vector2.zero;
						rectTransform.sizeDelta = Vector3.zero;
						RScqPMstlAuftSCCzVaWqpmAxtK = base.gameObject.AddComponent<Text>();
						RScqPMstlAuftSCCzVaWqpmAxtK.color = Color.white;
						RScqPMstlAuftSCCzVaWqpmAxtK.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
						num = 257294320;
						continue;
					case 9:
						if (xTgWlRGCEYGQjfhNKIonAtpNDjgk)
						{
							RScqPMstlAuftSCCzVaWqpmAxtK.color = aEIfrTEAytBkjhfuOMMTylHLHzW;
							num = 257294313;
							continue;
						}
						goto case 20;
					case 2:
						LYUUCNQWPbqnACMmeTehIyqanRO = RScqPMstlAuftSCCzVaWqpmAxtK.alignment;
						num = 257294324;
						continue;
					case 22:
						num = 257294314;
						continue;
					case 6:
						if (pIOWRYwVGxMsXcYvwJUvZJNhWJE)
						{
							RScqPMstlAuftSCCzVaWqpmAxtK.fontStyle = oXkXXsMHFSiBGlseUEnWOILzeCX;
							num = 257294318;
							continue;
						}
						goto case 7;
					case 10:
						return;
					}
					int num2;
					if (!hMmcbpXCkaEfHBTexyZnlMbndjr)
					{
						num = 257294304;
						num2 = num;
					}
					else
					{
						num = 257294322;
						num2 = num;
					}
					continue;
					IL_0154:
					RScqPMstlAuftSCCzVaWqpmAxtK.fontSize = 13;
					int num3;
					if (!wWZZzxMbLVAENXvUkCNRyMNzUmy)
					{
						num = 257294307;
						num3 = num;
					}
					else
					{
						num = 257294306;
						num3 = num;
					}
					continue;
					end_IL_0010:
					break;
				}
				goto IL_00aa;
				IL_00aa:
				RScqPMstlAuftSCCzVaWqpmAxtK = GetComponent<Text>();
				if (RScqPMstlAuftSCCzVaWqpmAxtK == null)
				{
					rectTransform = base.gameObject.AddComponent<RectTransform>();
					rectTransform.anchorMax = new Vector2(1f, 1f);
					num = 257294317;
					goto IL_0010;
				}
				break;
			}
		}

		private void fktyQwVxYAnidGQIpbfXGjHGmKoA()
		{
			if (!Application.isPlaying)
			{
				goto IL_0007;
			}
			goto IL_003f;
			IL_0007:
			int num = -1651952309;
			goto IL_000c;
			IL_000c:
			while (true)
			{
				switch (num ^ -1651952310)
				{
				case 5:
					break;
				default:
					return;
				case 3:
					RScqPMstlAuftSCCzVaWqpmAxtK = null;
					num = -1651952310;
					continue;
				case 4:
					goto IL_003f;
				case 2:
					RScqPMstlAuftSCCzVaWqpmAxtK.text = string.Empty;
					num = -1651952311;
					continue;
				case 1:
					return;
				case 0:
					return;
				}
				break;
			}
			goto IL_0007;
			IL_003f:
			int num2;
			if (RScqPMstlAuftSCCzVaWqpmAxtK != null)
			{
				num = -1651952312;
				num2 = num;
			}
			else
			{
				num = -1651952311;
				num2 = num;
			}
			goto IL_000c;
		}

		private void FmgLuFMehDTdyRLUIKbAuEmhouB()
		{
			bdRuCsmbBycMukFQpvnghGpVGKs = new GUIStyle(GUI.skin.label);
			if (!wWZZzxMbLVAENXvUkCNRyMNzUmy)
			{
				goto IL_00ea;
			}
			bdRuCsmbBycMukFQpvnghGpVGKs.alignment = LYUUCNQWPbqnACMmeTehIyqanRO;
			goto IL_0146;
			IL_00ea:
			LYUUCNQWPbqnACMmeTehIyqanRO = bdRuCsmbBycMukFQpvnghGpVGKs.alignment;
			int num = 1264423100;
			goto IL_003b;
			IL_0146:
			if (hMmcbpXCkaEfHBTexyZnlMbndjr)
			{
				bdRuCsmbBycMukFQpvnghGpVGKs.font = UARPaRMnyQRCkKnujsKVimqkHuH;
				num = 1264423094;
				goto IL_003b;
			}
			goto IL_01c9;
			IL_01c9:
			UARPaRMnyQRCkKnujsKVimqkHuH = bdRuCsmbBycMukFQpvnghGpVGKs.font;
			num = 1264423094;
			goto IL_003b;
			IL_003b:
			while (true)
			{
				switch (num ^ 0x4B5D90BF)
				{
				case 5:
					num = 1264423102;
					continue;
				default:
					return;
				case 4:
					bdRuCsmbBycMukFQpvnghGpVGKs.fontStyle = oXkXXsMHFSiBGlseUEnWOILzeCX;
					num = 1264423095;
					continue;
				case 7:
					if (xTgWlRGCEYGQjfhNKIonAtpNDjgk)
					{
						bdRuCsmbBycMukFQpvnghGpVGKs.normal.textColor = aEIfrTEAytBkjhfuOMMTylHLHzW;
						num = 1264423089;
						continue;
					}
					goto case 12;
				case 15:
					break;
				case 1:
					goto end_IL_003b;
				case 9:
					goto IL_0105;
				case 8:
					num = 1264423096;
					continue;
				case 6:
					bdRuCsmbBycMukFQpvnghGpVGKs.fontSize = yRMLrOdRnRtfrbUqACmYWAoqedy;
					num = 1264423093;
					continue;
				case 3:
					goto IL_0146;
				case 10:
					num = 1264423088;
					continue;
				case 11:
					oXkXXsMHFSiBGlseUEnWOILzeCX = bdRuCsmbBycMukFQpvnghGpVGKs.fontStyle;
					num = 1264423096;
					continue;
				case 13:
					yRMLrOdRnRtfrbUqACmYWAoqedy = bdRuCsmbBycMukFQpvnghGpVGKs.fontSize;
					num = 1264423088;
					continue;
				case 12:
					aEIfrTEAytBkjhfuOMMTylHLHzW = bdRuCsmbBycMukFQpvnghGpVGKs.normal.textColor;
					num = 1264423103;
					continue;
				case 2:
					goto IL_01c9;
				case 14:
					return;
				case 0:
					return;
				}
				int num2;
				if (!pIOWRYwVGxMsXcYvwJUvZJNhWJE)
				{
					num = 1264423092;
					num2 = num;
				}
				else
				{
					num = 1264423099;
					num2 = num;
				}
				continue;
				IL_0105:
				int num3;
				if (!pLcZxVwPpPPsfLYcbABnmZqnAdm)
				{
					num = 1264423090;
					num3 = num;
				}
				else
				{
					num = 1264423097;
					num3 = num;
				}
				continue;
				end_IL_003b:
				break;
			}
			goto IL_00ea;
		}

		[CustomObfuscation(rename = false)]
		internal static GUIText GetOrAddComponent(GameObject gameObject)
		{
			if (gameObject == null)
			{
				goto IL_0009;
			}
			GUIText gUIText = gameObject.GetComponent<GUIText>();
			int num = -1599422993;
			goto IL_000e;
			IL_000e:
			while (true)
			{
				switch (num ^ -1599422995)
				{
				case 0:
					break;
				case 1:
					return null;
				case 2:
				{
					int num2;
					if (!(gUIText == null))
					{
						num = -1599422994;
						num2 = num;
					}
					else
					{
						num = -1599422999;
						num2 = num;
					}
					continue;
				}
				case 4:
					gUIText = gameObject.AddComponent<GUIText>();
					num = -1599422994;
					continue;
				default:
					return gUIText;
				}
				break;
			}
			goto IL_0009;
			IL_0009:
			num = -1599422996;
			goto IL_000e;
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
