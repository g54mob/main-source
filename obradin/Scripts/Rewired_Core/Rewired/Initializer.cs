using System;
using System.ComponentModel;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	public sealed class Initializer : MonoBehaviour
	{
		[SerializeField]
		private GameObject _inputManagerPrefab;

		[SerializeField]
		private bool _destroySelf = true;

		public GameObject inputManagerPrefab
		{
			get
			{
				return _inputManagerPrefab;
			}
			set
			{
				_inputManagerPrefab = value;
			}
		}

		public bool destroySelf
		{
			get
			{
				return _destroySelf;
			}
			set
			{
				_destroySelf = value;
			}
		}

		private void Awake()
		{
			Initialize();
		}

		public bool Initialize()
		{
			bool result = default(bool);
			try
			{
				if (ReInput.isReady)
				{
					goto IL_000a;
				}
				goto IL_011e;
				IL_000a:
				int num = -908515228;
				goto IL_000f;
				IL_000f:
				GameObject gameObject = default(GameObject);
				string text = default(string);
				while (true)
				{
					switch (num ^ -908515229)
					{
					case 9:
						break;
					case 5:
						goto end_IL_0000;
					case 2:
						gameObject.name = text.Substring(0, text.Length - 7);
						num = -908515223;
						continue;
					case 6:
						goto IL_0077;
					case 3:
						text = gameObject.name;
						num = -908515227;
						continue;
					case 11:
						gameObject = UnityTools.Instantiate<GameObject>(_inputManagerPrefab, base.transform.parent, false);
						if (!(gameObject == null))
						{
							goto case 3;
						}
						Logger.LogError("Error instantiating prefab.");
						result = false;
						goto end_IL_0000;
					case 8:
						result = false;
						goto end_IL_0000;
					case 0:
						goto IL_00f7;
					case 1:
						goto IL_011e;
					case 7:
						result = false;
						goto end_IL_0000;
					case 4:
						Logger.LogError("Rewired Input Manager component is missing on the prefab.");
						num = -908515221;
						continue;
					default:
						result = true;
						goto end_IL_0000;
					}
					break;
					IL_0077:
					int num2;
					if (text.EndsWith("(clone)", StringComparison.OrdinalIgnoreCase))
					{
						num = -908515231;
						num2 = num;
					}
					else
					{
						num = -908515223;
						num2 = num;
					}
				}
				goto IL_000a;
				IL_011e:
				if (_inputManagerPrefab == null)
				{
					Logger.LogError("Rewired Input Manager prefab has not been set in the inspector. Cannot initialize Rewired.");
					result = false;
					num = -908515226;
					goto IL_000f;
				}
				goto IL_00f7;
				IL_00f7:
				int num3;
				if (UnityTools.GetComponentInSelfOrChildren<InputManager_Base>(_inputManagerPrefab) == null)
				{
					num = -908515225;
					num3 = num;
				}
				else
				{
					num = -908515224;
					num3 = num;
				}
				goto IL_000f;
				end_IL_0000:;
			}
			catch
			{
				result = false;
			}
			finally
			{
				if (destroySelf)
				{
					while (true)
					{
						IL_0175:
						int num4 = -908515230;
						while (true)
						{
							switch (num4 ^ -908515229)
							{
							case 0:
								break;
							default:
								goto end_IL_017a;
							case 1:
								goto IL_0193;
							case 2:
								goto end_IL_017a;
							}
							goto IL_0175;
							IL_0193:
							UnityEngine.Object.Destroy(base.gameObject);
							num4 = -908515231;
							continue;
							end_IL_017a:
							break;
						}
						break;
					}
				}
			}
			return result;
		}
	}
}
