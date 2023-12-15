using System;

interface Button
{
    void render();
    void onClick(Action f);
}

class WindowsButton : Button
{
    public void render()
    {
    }

    public void onClick(Action f)
    {
    }
}

class HTMLButton : Button
{
    public void render()
    {
    }

    public void onClick(Action f)
    {
    }
}

abstract class Dialog
{
    public void render()
    {
        Button okButton = createButton();
        okButton.onClick(closeDialog);
        okButton.render();
    }

    protected abstract Button createButton();

    private void closeDialog()
    {
    }
}

class WindowsDialog : Dialog
{
    protected override Button createButton()
    {
        return new WindowsButton();
    }
}

class WebDialog : Dialog
{
    protected override Button createButton()
    {
        return new HTMLButton();
    }
}

class Application
{
    private Dialog dialog;

    public void initialize()
    {
        Config config = readApplicationConfigFile();

        if (config.OS == "Windows")
        {
            dialog = new WindowsDialog();
        }
        else if (config.OS == "Web")
        {
            dialog = new WebDialog();
        }
        else
        {
            throw new Exception("Error! Unknown operating system.");
        }
    }

    public void main()
    {
        initialize();
        dialog.render();
    }

    private Config readApplicationConfigFile()
    {
        return new Config();
    }
}

class Config
{
    public string OS { get; set; }
}

internal class Program
{
    static void Main(string[] args)
    {
        Application app = new Application();
        app.main();
    }
}
