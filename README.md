# BDOWebMarket
**Используйте на свой страх и риск. Рекомендую использовать задержку между запросами.**

1.Чтобы получить **TradeAuth_Session** и **__RequestVerificationToken** cookie, нужно зайти веб маркет своего региона. 

2.После логина и ввода пинкода , откройте панель разработчика(Chrome: Crtl + Shift + I или F12),
октройте вкладку **Сеть(Network)** и выберите фильтр **Fetch/XHR.**

3.Кликните по категории затем по подкатегории вебмаркета , в панели разработчика появится запрос **"GetWorldMarketList".**

4.Перейдите в вкладку **"Файлы cookie"(Cookies)** и скопируйте значения строк **"TradeAuth_Session"(COOKIE_TRADE_AUTH)**
и **"__RequestVerificationToken"(COOKIE_REQUEST_VERIFICATION_TOKEN).**

5.Теперь, перейдите в вкладку **"Полезная нагрузка"(Payload)** и скопируйте значения **__RequestVerificationToken(QUERY_REQUEST_VERFICATION_TOKEN)**.

6.Вставте все полученные значения и введите названия региона в сокращенном ввиде(см. ниже) .
 
С параметрами запроса можете ознакомиться на сайте  https://developers.veliainn.com/ .

## Регионы:
- na - Северная Америка
- eu - Европа
- sea - Южная Восточная Азия
- mena - Турция
- kr - Южная Корея
- ru - Россия
- jp - Япония
- tw - Тайвань
- sa - Южная Америка
- console_eu - PS/XBOX Европа
- console_na - PS/XBOX Америка
- console_asia - PS/XBOX Азия 

