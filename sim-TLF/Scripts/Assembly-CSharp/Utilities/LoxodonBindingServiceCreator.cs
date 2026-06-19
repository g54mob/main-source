using Loxodon.Framework.Binding;
using Loxodon.Framework.Contexts;
using UnityEngine;

namespace Utilities
{
	public class LoxodonBindingServiceCreator : MonoBehaviour
	{
		private void Awake()
		{
			new BindingServiceBundle(Context.GetApplicationContext().GetContainer()).Start();
		}
	}
}
