using System.Windows;
using UserDBManager.ViewModel;

namespace UserDBManager;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private UserViewModel userViewModel = new();
    public MainWindow()
    {
        InitializeComponent();
        DataContext = userViewModel;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var addUserwindow = new AddUserwindow();
        addUserwindow.Show();

        Close();
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        var editUserWindow = new EditUserWindow();
        editUserWindow.Show();

        if (editUserWindow.DataContext is EditViewModel editViewModel)
        {
            editViewModel.EditingUser = userViewModel.SelectedUser;
        }

        Close();
    }
}