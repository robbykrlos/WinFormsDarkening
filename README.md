# WinFormsDarkening
.NET Library class that darkens the Windows form background;

# Install

### Add project reference
Add project reference to "WinFormsDarkening" (as project or pre-loaded dll);

### Add code
In the targeted YourForm.cs you want to darken add:
```
public void GoDarker()
{
    List<Type> targetedTypes = new List<Type>();
    //targetedTypes.Add(typeof(Button));
    //targetedTypes.Add(typeof(Form));

    DarkFormThemeHandler.DarkenFormControls(this, targetedTypes, true, Color.White, true);
    
    //DarkenFormControls(Form form, List<Type> controlTypes, bool noBorders, Color contrastTextColor, bool selfDarken)
    //If Type list is empty, it will target all controls.
}
```

And at your choice trigger/event (on load, on keybind etc):

```
GoDarker();
```

###
Note: this library is not meant for PROD. It is just a test. Some controls are not converting nicely to "darke mode". .NET support is limited for some cases and "hard-coded" color are still remining as default.

Note: If yout est the existing Win form test "WinFormsDarkeningTest" - just press F8 to test the Darken.
