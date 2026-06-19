using Loxodon.Framework.Binding;
using Loxodon.Framework.Contexts;
using UnityEngine;

public class MainMenuInitializer : MonoBehaviour
{
	private BindingServiceBundle _bindingServiceBundle;

	private void Awake()
	{
		BindingServiceBundle bindingServiceBundle = new BindingServiceBundle(Context.GetApplicationContext().GetContainer());
		bindingServiceBundle.Start();
		_bindingServiceBundle = bindingServiceBundle;
	}

	private void OnDestroy()
	{
		_bindingServiceBundle.Stop();
	}
}
