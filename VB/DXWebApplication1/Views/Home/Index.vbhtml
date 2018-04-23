<script type="text/javascript">
    var i = 0;
    var interval = 1000;
    var isReady = false;
    var intervalId = null;

    var urlTemplate = '@Url.Action("RenderGauge", "Home", New RouteValueDictionary(New With {.param = -1.0F}))';

    function btn1_OnClick(s, e) {
        document.getElementById('gaugeImg1').src = urlTemplate.replace("-1", spin.GetValue().toString());
    }

    function btn2_OnClick(s, e) {
        i = 0;

        if (interval != null) {
            clearInterval(intervalId);
            intervalId = null;
        }

        intervalId = setInterval(function () {
            if (isReady) {
                isReady = false;

                if (i > 100)
                    clearInterval(intervalId);

                document.getElementById('gaugeImg2').src = urlTemplate.replace("-1", i);
                i += 5;
            }
        }, interval);
    }

    function ImageReady() { isReady = true; }
</script>
<div style="background: 1px solid Blue; width; 240px;">
    <table>
        <thead>
            <th colspan="2" style="width: 300px">
                <img src='@Url.Action("RenderGauge", "Home", New RouteValueDictionary(New With {.param = 23.0F}))'
                    alt="Gauge showing data" id="gaugeImg1" />
            </th>
            <th style="width: 300px">
                <img src='@Url.Action("RenderGauge", "Home", New RouteValueDictionary(New With {.param = 7.0F}))'
                    alt="Gauge showing data" id="gaugeImg2" onload="ImageReady()" />
            </th>
        </thead>
        <tbody>
            <td>
                @Html.DevExpress().SpinEdit(Sub(settings)
                                                settings.Name = "spin"
                                                settings.Properties.NullText = "Enter a value"
                                                settings.Properties.NumberFormat = SpinEditNumberFormat.Number
                                                settings.Properties.NumberType = SpinEditNumberType.Integer
                                                settings.Properties.MinValue = 0
                                                settings.Properties.MaxValue = 100
                                                settings.Properties.ValidationSettings.ValidationGroup = "gaugeImg"
                                                settings.Properties.ValidationSettings.RequiredField.IsRequired = True
                                                settings.Properties.ValidationSettings.Display = Display.Dynamic
                                                settings.Properties.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.ImageWithTooltip
                                                settings.Width = Unit.Percentage(100)
                                                settings.Properties.AllowNull = False
                                            End Sub).GetHtml()
            </td>
            <td>
                @Html.DevExpress().Button(Sub(settings)
                                              settings.Name = "btn1"
                                              settings.Text = "Apply"
                                              settings.ClientSideEvents.Click = "btn1_OnClick"
                                              settings.ValidationGroup = "group"
                                          End Sub).GetHtml()
            </td>
            <td align="center">
                @Html.DevExpress().Button(Sub(settings)
                                              settings.Name = "btn2"
                                              settings.Text = "Start Animation"
                                              settings.ClientSideEvents.Click = "btn2_OnClick"
                                          End Sub).GetHtml()
            </td>
        </tbody>
    </table>
</div>