using System;
using MG_BlocksEngine2.Block;
using UnityEngine.Events;

namespace MG_BlocksEngine2.Core
{
	[Serializable]
	public class BE2_Event : UnityEvent<I_BE2_Block>
	{
	}
}
