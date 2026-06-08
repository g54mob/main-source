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
					result = false;
				}
				else
				{
					GameObject gameObject = default(GameObject);
					string text = default(string);
					while (true)
					{
						if (_inputManagerPrefab == null)
						{
							Logger.LogError("Rewired Input Manager prefab has not been set in the inspector. Cannot initialize Rewired.");
							result = false;
							break;
						}
						while (true)
						{
							IL_0126:
							int num;
							if (UnityTools.GetComponentInSelfOrChildren<InputManager_Base>(_inputManagerPrefab) == null)
							{
								Logger.LogError("Rewired Input Manager component is missing on the prefab.");
								result = false;
								num = 1156751018;
								goto IL_0013;
							}
							goto IL_0078;
							IL_0013:
							while (true)
							{
								switch (num ^ 0x44F29EA3)
								{
								case 5:
									num = 1156751013;
									continue;
								case 6:
									break;
								case 10:
									goto IL_0078;
								case 3:
									goto IL_009a;
								case 1:
									gameObject.name = text.Substring(0, text.Length - 7);
									num = 1156751012;
									continue;
								case 8:
									goto end_IL_004f;
								case 9:
									goto end_IL_004f;
								case 2:
									result = false;
									num = 1156751019;
									continue;
								case 0:
									if (gameObject == null)
									{
										Logger.LogError("Error instantiating prefab.");
										num = 1156751009;
										continue;
									}
									goto IL_009a;
								case 4:
									goto IL_0126;
								default:
									result = true;
									goto end_IL_004f;
								}
								break;
								IL_009a:
								text = gameObject.name;
								int num2;
								if (!text.EndsWith("(clone)", StringComparison.OrdinalIgnoreCase))
								{
									num = 1156751012;
									num2 = num;
								}
								else
								{
									num = 1156751010;
									num2 = num;
								}
							}
							break;
							IL_0078:
							gameObject = UnityTools.Instantiate<GameObject>(_inputManagerPrefab, base.transform.parent, instantiateInWorldSpace: false);
							num = 1156751011;
							goto IL_0013;
						}
						continue;
						end_IL_004f:
						break;
					}
				}
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
