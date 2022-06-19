# WindowsScaleWarning
Warns you an application is opening that'll be poorly affected by the Windows scale feature.

## How To
Once you open the application, it will start running in the background. If an application opens which is listed in the `watch.json` file, a window will popup warning you
there is a problematic application being launched. The popup gives you an option to ignore the warning or kill the app.

## Configuration
You can configure the application using the `watch.json` file, which allows you to add more applications that
WSW should warn you about.

```json
[
  {
    "name": "Dead By Daylight",
    "process": "DeadByDaylight-Win64-Shipping",
    "auto-kill": false
  }
]
```

Here is a detailed explenation of each property in the watch objects.

Name | Description | Default
---- | ----------- | --------
`name` | Human friendly name of the application | **REQUIRED**
`process` | Name of the process without `.exe` This can be found in the task manager. | **REQUIRED**
`auto-kill` | Auto kills the application, but still shows a popup. | `false`
