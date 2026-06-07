using System;
using System.ComponentModel;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
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
				goto IL_00a9;
				IL_000a:
				int num = 1415032255;
				goto IL_000f;
				IL_000f:
				string text = default(string);
				GameObject gameObject = default(GameObject);
				while (true)
				{
					switch (num ^ 0x5457ADBA)
					{
					case 0:
						break;
					default:
						goto end_IL_0000;
					case 7:
						result = false;
						goto end_IL_0000;
					case 3:
						goto IL_0065;
					case 2:
						goto end_IL_0000;
					case 13:
						text = gameObject.name;
						num = 1415032242;
						continue;
					case 11:
						goto IL_00a9;
					case 9:
						result = false;
						goto end_IL_0000;
					case 6:
						result = true;
						num = 1415032240;
						continue;
					case 12:
						Logger.LogError("Error instantiating prefab.");
						result = false;
						goto end_IL_0000;
					case 8:
						if (text.EndsWith("(clone)", StringComparison.OrdinalIgnoreCase))
						{
							gameObject.name = text.Substring(0, text.Length - 7);
							num = 1415032252;
							continue;
						}
						goto case 6;
					case 5:
						result = false;
						num = 1415032248;
						continue;
					case 1:
						Logger.LogError("Rewired Input Manager component is missing on the prefab.");
						num = 1415032253;
						continue;
					case 4:
						goto IL_0150;
					case 10:
						goto end_IL_0000;
					}
					break;
					IL_0150:
					gameObject = UnityTools.Instantiate<GameObject>(_inputManagerPrefab, base.transform.parent, false);
					int num2;
					if (!(gameObject == null))
					{
						num = 1415032247;
						num2 = num;
					}
					else
					{
						num = 1415032246;
						num2 = num;
					}
				}
				goto IL_000a;
				IL_00a9:
				if (_inputManagerPrefab == null)
				{
					Logger.LogError("Rewired Input Manager prefab has not been set in the inspector. Cannot initialize Rewired.");
					num = 1415032243;
					goto IL_000f;
				}
				goto IL_0065;
				IL_0065:
				int num3;
				if (UnityTools.GetComponentInSelfOrChildren<InputManager_Base>(_inputManagerPrefab) == null)
				{
					num = 1415032251;
					num3 = num;
				}
				else
				{
					num = 1415032254;
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
					UnityEngine.Object.Destroy(base.gameObject);
				}
			}
			return result;
		}
	}
}
