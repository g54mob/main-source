using System.Threading.Tasks;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Contexts;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.Views;
using Loxodon.Framework.Views.InteractionActions;
using Loxodon.Log;
using UnityEngine;
using UnityEngine.UI;

namespace Loxodon.Framework.Examples
{
	public class StartupWindow : Window
	{
		private class AsynSceneInteractionAction : AsyncInteractionActionBase<ProgressBar>
		{
			private string path;

			public AsynSceneInteractionAction(string path)
			{
				this.path = path;
			}

			public override async Task Action(ProgressBar progressBar)
			{
				progressBar.Enable = true;
				progressBar.Tip = R.startup_progressbar_tip_loading;
				try
				{
					ResourceRequest request = Resources.LoadAsync<GameObject>(path);
					while (!request.isDone)
					{
						progressBar.Progress = request.progress;
						await new WaitForSecondsRealtime(0.02f);
					}
					Object.Instantiate((GameObject)request.asset);
				}
				finally
				{
					progressBar.Tip = "";
					progressBar.Enable = false;
				}
			}
		}

		private static readonly ILog log = LogManager.GetLogger(typeof(StartupWindow));

		public Text progressBarText;

		public Slider progressBarSlider;

		public Text tipText;

		public Button button;

		private StartupViewModel viewModel;

		private IUIViewLocator viewLocator;

		private AsyncWindowInteractionAction loginWindowInteractionAction;

		private AsynSceneInteractionAction sceneInteractionAction;

		protected override void OnCreate(IBundle bundle)
		{
			viewLocator = Context.GetApplicationContext().GetService<IUIViewLocator>();
			loginWindowInteractionAction = new AsyncWindowInteractionAction("UI/Logins/Login", viewLocator, base.WindowManager);
			sceneInteractionAction = new AsynSceneInteractionAction("Prefabs/Cube");
			viewModel = new StartupViewModel();
			BindingSet<StartupWindow, StartupViewModel> bindingSet = this.CreateBindingSet(viewModel);
			bindingSet.Bind().For((StartupWindow v) => v.loginWindowInteractionAction).To((StartupViewModel vm) => vm.LoginRequest);
			bindingSet.Bind().For((StartupWindow v) => v.OnDismissRequest).To((StartupViewModel vm) => vm.DismissRequest);
			bindingSet.Bind().For((StartupWindow v) => v.sceneInteractionAction).To((StartupViewModel vm) => vm.LoadSceneRequest);
			bindingSet.Bind(progressBarSlider).For("value", "onValueChanged").To("ProgressBar.Progress")
				.TwoWay();
			bindingSet.Bind(progressBarSlider.gameObject).For((GameObject v) => v.activeSelf).To((StartupViewModel vm) => vm.ProgressBar.Enable)
				.OneWay();
			bindingSet.Bind(progressBarText).For((Text v) => v.text).ToExpression((StartupViewModel vm) => $"{Mathf.FloorToInt(vm.ProgressBar.Progress * 100f)}%")
				.OneWay();
			bindingSet.Bind(tipText).For((Text v) => v.text).To((StartupViewModel vm) => vm.ProgressBar.Tip)
				.OneWay();
			bindingSet.Bind(button).For((Button v) => v.onClick).To((StartupViewModel vm) => vm.Click)
				.OneWay();
			bindingSet.Build();
			viewModel.Unzip();
		}

		protected void OnDismissRequest(object sender, InteractionEventArgs args)
		{
			Dismiss();
		}
	}
}
