using System;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	public sealed class InputAction
	{
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int _id;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string _name;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private InputActionType _type;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _descriptiveName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _positiveDescriptiveName;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string _negativeDescriptiveName;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int _behaviorId;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _userAssignable;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _categoryId;

		[NonSerialized]
		private string DxDEfNlxvoqdmMzXEtFIDljgsng;

		[NonSerialized]
		private string FHYCZsUVmyWHKxVUVAMoBptfKND;

		public int id
		{
			get
			{
				return _id;
			}
			internal set
			{
				_id = value;
			}
		}

		public string name
		{
			get
			{
				return _name;
			}
			internal set
			{
				_name = value;
			}
		}

		public InputActionType type
		{
			get
			{
				return _type;
			}
			internal set
			{
				_type = value;
			}
		}

		public string descriptiveName
		{
			get
			{
				return _descriptiveName;
			}
			internal set
			{
				_descriptiveName = value;
			}
		}

		public string positiveDescriptiveName
		{
			get
			{
				if (Application.isPlaying)
				{
					while (true)
					{
						int num = -1689633586;
						while (true)
						{
							switch (num ^ -1689633587)
							{
							case 2:
								break;
							case 3:
								goto IL_0029;
							case 0:
								goto end_IL_0007;
							default:
								goto IL_006e;
							}
							break;
							IL_0029:
							if (!string.IsNullOrEmpty(_positiveDescriptiveName))
							{
								num = -1689633587;
								continue;
							}
							if (string.IsNullOrEmpty(DxDEfNlxvoqdmMzXEtFIDljgsng))
							{
								DxDEfNlxvoqdmMzXEtFIDljgsng = _descriptiveName + " +";
								num = -1689633588;
								continue;
							}
							goto IL_006e;
							IL_006e:
							return DxDEfNlxvoqdmMzXEtFIDljgsng;
						}
						continue;
						end_IL_0007:
						break;
					}
				}
				return _positiveDescriptiveName;
			}
			internal set
			{
				_positiveDescriptiveName = value;
				DxDEfNlxvoqdmMzXEtFIDljgsng = string.Empty;
			}
		}

		public string negativeDescriptiveName
		{
			get
			{
				if (!Application.isPlaying)
				{
					goto IL_0032;
				}
				if (!string.IsNullOrEmpty(_negativeDescriptiveName))
				{
					goto IL_0014;
				}
				int num;
				if (string.IsNullOrEmpty(FHYCZsUVmyWHKxVUVAMoBptfKND))
				{
					FHYCZsUVmyWHKxVUVAMoBptfKND = _descriptiveName + " -";
					num = -184950901;
					goto IL_0019;
				}
				goto IL_0063;
				IL_0019:
				switch (num ^ -184950901)
				{
				case 2:
					break;
				case 1:
					goto IL_0032;
				default:
					goto IL_0063;
				}
				goto IL_0014;
				IL_0032:
				return _negativeDescriptiveName;
				IL_0063:
				return FHYCZsUVmyWHKxVUVAMoBptfKND;
				IL_0014:
				num = -184950902;
				goto IL_0019;
			}
			internal set
			{
				_negativeDescriptiveName = value;
				FHYCZsUVmyWHKxVUVAMoBptfKND = string.Empty;
			}
		}

		public int behaviorId
		{
			get
			{
				return _behaviorId;
			}
			internal set
			{
				_behaviorId = value;
			}
		}

		public int categoryId
		{
			get
			{
				return _categoryId;
			}
			internal set
			{
				_categoryId = value;
			}
		}

		public bool userAssignable
		{
			get
			{
				return _userAssignable;
			}
			internal set
			{
				_userAssignable = value;
			}
		}

		public InputAction()
		{
		}

		public InputAction(InputAction source)
		{
			_id = source._id;
			_name = source._name;
			_type = source._type;
			_descriptiveName = source._descriptiveName;
			_positiveDescriptiveName = source._positiveDescriptiveName;
			_negativeDescriptiveName = source._negativeDescriptiveName;
			_behaviorId = source._behaviorId;
			_userAssignable = source._userAssignable;
			_categoryId = source.categoryId;
		}

		public InputAction Clone()
		{
			return new InputAction(this);
		}
	}
}
