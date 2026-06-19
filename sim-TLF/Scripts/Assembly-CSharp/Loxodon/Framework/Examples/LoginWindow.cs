using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.Views;
using Loxodon.Framework.Views.InteractionActions;
using UnityEngine.UI;

namespace Loxodon.Framework.Examples
{
	public class LoginWindow : Window
	{
		public InputField username;

		public InputField password;

		public Text usernameErrorPrompt;

		public Text passwordErrorPrompt;

		public Button confirmButton;

		public Button cancelButton;

		private ToastInteractionAction toastAction;

		protected override void OnCreate(IBundle bundle)
		{
			toastAction = new ToastInteractionAction(this);
			BindingSet<LoginWindow, LoginViewModel> bindingSet = this.CreateBindingSet<LoginWindow, LoginViewModel>();
			bindingSet.Bind().For((LoginWindow v) => v.OnInteractionFinished).To((LoginViewModel vm) => vm.InteractionFinished);
			bindingSet.Bind().For((LoginWindow v) => v.toastAction).To((LoginViewModel vm) => vm.ToastRequest);
			bindingSet.Bind(username).For((InputField v) => v.text, (InputField v) => v.onEndEdit).To((LoginViewModel vm) => vm.Username)
				.TwoWay();
			bindingSet.Bind(usernameErrorPrompt).For((Text v) => v.text).To((LoginViewModel vm) => vm.Errors["username"])
				.OneWay();
			bindingSet.Bind(password).For((InputField v) => v.text, (InputField v) => v.onEndEdit).To((LoginViewModel vm) => vm.Password)
				.TwoWay();
			bindingSet.Bind(passwordErrorPrompt).For((Text v) => v.text).To((LoginViewModel vm) => vm.Errors["password"])
				.OneWay();
			bindingSet.Bind(confirmButton).For((Button v) => v.onClick).To((LoginViewModel vm) => vm.LoginCommand);
			bindingSet.Bind(cancelButton).For((Button v) => v.onClick).To((LoginViewModel vm) => vm.CancelCommand);
			bindingSet.Build();
		}

		public virtual void OnInteractionFinished(object sender, InteractionEventArgs args)
		{
			Dismiss();
		}
	}
}
