using System;
using Eto.Forms;
using Eto.Drawing;

namespace EtoApp7
{
    public class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent(new MainFormViewModel());
        }

        private void InitializeComponent(MainFormViewModel dataContext)
        {
            Title = "My Eto Form";
            ClientSize = new Size(400, 350);
            DataContext = dataContext;

            var button = new Button() { Text = "test" };
            button.TextBinding.Bind(dataContext, dc => dc.Test);
            button.Bind(tb => tb.Enabled, dataContext, dc => dc.Enabled);
            button.Click += (_1, _2) => dataContext.F();

            Content = new StackLayout
            {
                Padding = 10,
                Items =
                {
                    new Label() { Text = "Hello World!" },
                    button,
                }
            };

            // create a few commands that can be used for the menu and toolbar
            var clickMe = new Command { MenuText = "Click Me!", ToolBarText = "Click Me!" };
            clickMe.Executed += (sender, e) => MessageBox.Show(this, "I was clicked!");

            var quitCommand = new Command { MenuText = "Quit", Shortcut = Application.Instance.CommonModifier | Keys.Q };
            quitCommand.Executed += (sender, e) => Application.Instance.Quit();

            var aboutCommand = new Command { MenuText = "About..." };
            aboutCommand.Executed += (sender, e) => MessageBox.Show(this, "About my app...");

            // create menu
            Menu = new MenuBar
            {
                Items =
                {
					// File submenu
					new ButtonMenuItem { Text = "&File", Items = { clickMe } },
					// new ButtonMenuItem { Text = "&Edit", Items = { /* commands/items */ } },
					// new ButtonMenuItem { Text = "&View", Items = { /* commands/items */ } },
				},
                ApplicationItems =
                {
					// application (OS X) or file menu (others)
					new ButtonMenuItem { Text = "&Preferences..." },
                },
                QuitItem = quitCommand,
                AboutItem = aboutCommand
            };

            // create toolbar			
            ToolBar = new ToolBar { Items = { clickMe } };
        }
    }
}