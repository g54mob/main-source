using System;
using System.Diagnostics;
using UnityEngine;

namespace MagicaCloth2
{
	[Serializable]
	public struct ResultCode
	{
		[SerializeField]
		private Define.Result result;

		[SerializeField]
		private Define.Result warning;

		public Define.Result Result => default(Define.Result);

		public static ResultCode None => default(ResultCode);

		public static ResultCode Empty => default(ResultCode);

		public static ResultCode Success => default(ResultCode);

		public static ResultCode Error => default(ResultCode);

		public ResultCode(Define.Result initResult)
		{
			result = default(Define.Result);
			warning = default(Define.Result);
		}

		public void Clear()
		{
		}

		public void SetResult(Define.Result code)
		{
		}

		public void SetSuccess()
		{
		}

		public void SetCancel()
		{
		}

		public void SetError(Define.Result code = Define.Result.Error)
		{
		}

		public void SetWarning(Define.Result code = Define.Result.Warning)
		{
		}

		public void Merge(ResultCode src)
		{
		}

		public void SetProcess()
		{
		}

		public bool IsResult(Define.Result code)
		{
			return false;
		}

		public bool IsNone()
		{
			return false;
		}

		public bool IsSuccess()
		{
			return false;
		}

		public bool IsFaild()
		{
			return false;
		}

		public bool IsCancel()
		{
			return false;
		}

		public bool IsNormal()
		{
			return false;
		}

		public bool IsError()
		{
			return false;
		}

		public bool IsProcess()
		{
			return false;
		}

		public bool IsWarning()
		{
			return false;
		}

		public string GetResultString()
		{
			return null;
		}

		public string GetWarningString()
		{
			return null;
		}

		public string GetResultInformation()
		{
			return null;
		}

		public string GetWarningInformation()
		{
			return null;
		}

		[Conditional("MC2_DEBUG")]
		public void DebugLog(bool error = true, bool warning = true, bool normal = true)
		{
		}
	}
}
