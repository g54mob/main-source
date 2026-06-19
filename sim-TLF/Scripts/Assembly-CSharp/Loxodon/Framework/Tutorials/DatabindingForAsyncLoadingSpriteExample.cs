using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Contexts;
using UnityEngine;
using UnityEngine.UI;

namespace Loxodon.Framework.Tutorials
{
	public class DatabindingForAsyncLoadingSpriteExample : MonoBehaviour
	{
		public Button changeSpriteButton;

		public AsyncSpriteLoader spriteLoader;

		private void Awake()
		{
			new BindingServiceBundle(Context.GetApplicationContext().GetContainer()).Start();
		}

		private void Start()
		{
			SpriteViewModel dataContext = new SpriteViewModel();
			this.BindingContext().DataContext = dataContext;
			BindingSet<DatabindingForAsyncLoadingSpriteExample, SpriteViewModel> bindingSet = this.CreateBindingSet<DatabindingForAsyncLoadingSpriteExample, SpriteViewModel>();
			bindingSet.Bind(spriteLoader).For((AsyncSpriteLoader v) => v.SpriteName).To((SpriteViewModel vm) => vm.SpriteName)
				.OneWay();
			bindingSet.Bind(changeSpriteButton).For((Button v) => v.onClick).To((SpriteViewModel vm) => vm.ChangeSpriteName);
			bindingSet.Build();
		}
	}
}
