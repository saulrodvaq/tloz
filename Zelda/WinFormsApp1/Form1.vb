Public Class Zelda

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        My.Computer.Audio.Play(My.Resources.zelda_shop_song, AudioPlayMode.BackgroundLoop)
        temporizador.Visible = False
    End Sub

    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        Timer1.Enabled = True
        StartButton.Visible = False
        Timer1.Interval = 10
        Timer2.Interval = 10
    End Sub

    Dim HPLink As Integer = 30
    Dim CuracionReal1 As New PictureBox()
    Dim CuracionReal2 As New PictureBox()
    Dim velocidadEnemigo As Integer = 2
    Dim velocidad As Point = New Point(0, 0)
    Dim direccion As String = ""
    Dim tiempo1 As Integer
    Dim tiempo2 As Integer
    Dim tiempo3 As Integer
    Dim imagenArriba As Image = My.Resources.linkup
    Dim imagenAbajo As Image = My.Resources.linkdown
    Dim imagenIzquierda As Image = My.Resources.linkleft
    Dim imagenDerecha As Image = My.Resources.linkright
    Dim imagenMute As Image = My.Resources.mute
    Dim imagenUnmute As Image = My.Resources.unmute
    Dim imagenHitizq As Image = My.Resources.linkhitizq
    Dim imagenHitder As Image = My.Resources.linkhitder
    Dim imagenHitarriba As Image = My.Resources.linkhitarriba
    Dim imagenHitabajo As Image = My.Resources.linkhitabajo
    Private Atacando As Boolean = False

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.W
                direccion = "arriba"
                PictureBox1.Image = imagenArriba
                velocidad.Y = -5
            Case Keys.S
                direccion = "abajo"
                PictureBox1.Image = imagenAbajo
                velocidad.Y = 5
            Case Keys.A
                direccion = "izquierda"
                PictureBox1.Image = imagenIzquierda
                velocidad.X = -5
            Case Keys.D
                direccion = "derecha"
                PictureBox1.Image = imagenDerecha
                velocidad.X = 5
            Case Keys.F
                Select Case True
                    Case direccion = "izquierda"
                        PictureBox1.Size = New Size(130, 90)
                        PictureBox1.Image = imagenHitizq
                        Atacando = True
                        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Question)
                    Case direccion = "derecha"
                        PictureBox1.Size = New Size(130, 90)
                        PictureBox1.Image = imagenHitder
                        Atacando = True
                        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Beep)
                    Case direccion = "arriba"
                        PictureBox1.Size = New Size(90, 130)
                        PictureBox1.Image = imagenHitarriba
                        Atacando = True
                        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Exclamation)
                    Case direccion = "abajo"
                        PictureBox1.Size = New Size(90, 130)
                        PictureBox1.Image = imagenHitabajo
                        Atacando = True
                        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Asterisk)
                End Select
        End Select
    End Sub
    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.F OrElse e.KeyCode = Keys.A OrElse e.KeyCode = Keys.D OrElse e.KeyCode = Keys.W OrElse e.KeyCode = Keys.S Then
            velocidad = New Point(0, 0)
        End If
        If Atacando = True Then
            If e.KeyCode = Keys.F Then
                Select Case True
                    Case direccion = "izquierda"
                        PictureBox1.Size = New Size(68, 77)
                        PictureBox1.Image = imagenIzquierda
                        Atacando = False
                    Case direccion = "derecha"
                        PictureBox1.Size = New Size(68, 77)
                        PictureBox1.Image = imagenDerecha
                        Atacando = False
                    Case direccion = "arriba"
                        PictureBox1.Size = New Size(68, 77)
                        PictureBox1.Image = imagenArriba
                        Atacando = False
                    Case direccion = "abajo"
                        PictureBox1.Size = New Size(68, 77)
                        PictureBox1.Image = imagenAbajo
                        Atacando = False
                End Select
            End If
        End If
    End Sub
    Private Sub ActualizarHpVisual()
        Dim numCorazones As Integer = HPLink \ 10
        If HPLink Mod 10 > 0 Then
            numCorazones += 1
        End If

        Corazon1.Visible = numCorazones >= 1
        Corazon2.Visible = numCorazones >= 2
        Corazon3.Visible = numCorazones >= 3
    End Sub
    Private Sub RecibirDaño(daño As Integer)
        HPLink -= daño
        ActualizarHpVisual()

        If HPLink <= 0 Then
            Timer1.Stop()
            GameOver.Visible = True
            Restart.Visible = True
        End If
    End Sub

    Private Sub RecibirCura(cura As Integer)
        HPLink += cura
        ActualizarHpVisual()

        If HPLink > 30 Then
            HPLink = 30
        End If
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        tiempo1 = tiempo1 + 1
        temporizador.Text = tiempo1

        If temporizador.Text = 1 Then
            PRINCESA.Visible = True
            TITULO.Visible = False
            Corazon1.Visible = True
            Corazon2.Visible = True
            Corazon3.Visible = True
            Nivel.Visible = True
            Enemigo1.Visible = True
            Enemigo2.Visible = True
            Enemigo3.Visible = True
            Enemigo4.Visible = True
        End If
        If temporizador.Text = 100 Then
            PRINCESA.Visible = False
        End If
        If temporizador.Text = 800 Then
            Timer1.Stop()
            Timer2.Start()
            NivelCentro.Visible = True
            NivelCentro.Text = "Nivel 2"
            Nivel.Text = "Nivel 2"
            curaIMAGEN.Visible = True
            curaIMAGEN2.Visible = True
            CuracionReal1.Name = "CuracionReal1"
            CuracionReal1.Size = Curacion.Size
            CuracionReal1.Location = Curacion.Location
            CuracionReal1.BackColor = Color.Transparent
            CuracionReal2.Name = "CuracionReal2"
            CuracionReal2.Size = Curacion2.Size
            CuracionReal2.Location = Curacion2.Location
            CuracionReal2.BackColor = Color.Transparent
            Me.Controls.Add(CuracionReal1)
            Me.Controls.Add(CuracionReal2)
        End If
        If temporizador.Text = 1600 Then
            Timer1.Stop()
            Timer2.Start()
            NivelCentro.Visible = True
            NivelCentro.Text = "Nivel 3"
            Nivel.Text = "Nivel 3"
            curaIMAGEN.Visible = True
            curaIMAGEN2.Visible = True
            CuracionReal1.Name = "CuracionReal1"
            CuracionReal1.Size = Curacion.Size
            CuracionReal1.Location = Curacion.Location
            CuracionReal1.BackColor = Color.Transparent
            CuracionReal2.Name = "CuracionReal2"
            CuracionReal2.Size = Curacion2.Size
            CuracionReal2.Location = Curacion2.Location
            CuracionReal2.BackColor = Color.Transparent
            Me.Controls.Add(CuracionReal1)
            Me.Controls.Add(CuracionReal2)
        End If
        If temporizador.Text = 1650 Then
            BOSSBATTLE.Visible = True
        End If
        If temporizador.Text = 1670 Then
            BOSSBATTLE.Visible = False
        End If
        If temporizador.Text = 1690 Then
            BOSSBATTLE.Visible = True
        End If
        If temporizador.Text = 1710 Then
            BOSSBATTLE.Visible = False
        End If
        If temporizador.Text = 1730 Then
            BOSSBATTLE.Visible = True
        End If
        If temporizador.Text = 1750 Then
            BOSSBATTLE.Visible = False
        End If
        If temporizador.Text = 2250 Then
            SURVIVE.Visible = True
        End If
        If temporizador.Text = 2270 Then
            SURVIVE.Visible = False
        End If
        If temporizador.Text = 2290 Then
            SURVIVE.Visible = True
        End If
        If temporizador.Text = 2310 Then
            SURVIVE.Visible = False
        End If
        If temporizador.Text = 2330 Then
            SURVIVE.Visible = True
        End If
        If temporizador.Text = 2350 Then
            SURVIVE.Visible = False
        End If
        If temporizador.Text = 2400 Then
            curaIMAGEN.Visible = False
            curaIMAGEN2.Visible = False
            PictureBox1.Visible = False
            PictureBox4.Visible = False
            Corazon3.Visible = False
            Corazon2.Visible = False
            Corazon1.Visible = False
            PictureBox2.Visible = False
            PictureBox3.Visible = False
            NivelCentro.Visible = False
            Nivel.Visible = False
            Felicitacion.Visible = True
            Label1.Visible = True
            MasterSword.Visible = True
            Me.BackgroundImage = My.Resources.Negro
        End If

        If temporizador.Text = 2700 Then
            Felicitacion.Visible = False
            Label1.Visible = False
            MasterSword.Visible = False
            Dedicacion.Visible = True
            FelipeTijerina.Visible = True
            Agradecimiento.Visible = True
        End If
        If temporizador.Text = 3030 Then
            Close()
        End If
        Dim position As Point = PictureBox1.Location
        position.X += velocidad.X
        position.Y += velocidad.Y

        If position.X < 0 Then
            position.X = 0
        End If
        If position.X + PictureBox1.Width > Me.ClientSize.Width Then
            position.X = Me.ClientSize.Width - PictureBox1.Width
        End If
        If position.Y < 0 Then
            position.Y = 0
        End If
        If position.Y + PictureBox1.Height > Me.ClientSize.Height Then
            position.Y = Me.ClientSize.Height - PictureBox1.Height
        End If

        PictureBox1.Location = position

        For Each control As Control In Controls
            If TypeOf control Is PictureBox AndAlso control.Name.StartsWith("Pared") Then
                Dim objectRect As Rectangle = New Rectangle(control.Location, control.Size)
                Dim playerRect As Rectangle = New Rectangle(PictureBox1.Location, PictureBox1.Size)
                If objectRect.IntersectsWith(playerRect) Then
                    Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                    Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                    Dim angle As Double = Math.Atan2(dy, dx)

                    Dim pushSpeed As Integer = 5
                    velocidad.X = pushSpeed * Math.Cos(angle)
                    velocidad.Y = pushSpeed * Math.Sin(angle)
                End If
            End If
            '-------------------------------------Enemigo1
            If TypeOf control Is PictureBox AndAlso control.Name = "Enemigo1" Then
                Dim objectRect As Rectangle = New Rectangle(control.Location, control.Size)
                Dim playerRect As Rectangle = New Rectangle(PictureBox1.Location, PictureBox1.Size)
                If objectRect.IntersectsWith(playerRect) Then
                    If Atacando = False Then
                        Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                        Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                        Dim angle As Double = Math.Atan2(dy, dx)

                        Dim pushSpeed As Integer = 14
                        velocidad.X = pushSpeed * Math.Cos(angle)
                        velocidad.Y = pushSpeed * Math.Sin(angle)
                        RecibirDaño(10)
                        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Hand)
                    End If
                End If
                If objectRect.IntersectsWith(playerRect) Then
                    If Atacando = True Then
                        Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                        Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                        Dim angle As Double = Math.Atan2(dy, dx)
                        Enemigo1.Dispose()


                        Dim pushSpeed As Integer = 14
                        velocidad.X = pushSpeed * Math.Cos(angle)
                        velocidad.Y = pushSpeed * Math.Sin(angle)
                    End If
                End If
                If Enemigo1.Enabled Then
                    Dim direction As New Point(PictureBox1.Location.X - Enemigo1.Location.X, PictureBox1.Location.Y - Enemigo1.Location.Y)

                    Dim distance As Double = Math.Sqrt(direction.X ^ 2 + direction.Y ^ 2)

                    direction.X /= distance
                    direction.Y /= distance

                    Enemigo1.Left += CInt(direction.X * velocidadEnemigo)
                    Enemigo1.Top += CInt(direction.Y * velocidadEnemigo)
                End If

            End If
            '-------------------------------------Enemigo2
            If TypeOf control Is PictureBox AndAlso control.Name = "Enemigo2" Then
                Dim objectRect As Rectangle = New Rectangle(control.Location, control.Size)
                Dim playerRect As Rectangle = New Rectangle(PictureBox1.Location, PictureBox1.Size)
                If objectRect.IntersectsWith(playerRect) Then
                    If Atacando = False Then
                        Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                        Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                        Dim angle As Double = Math.Atan2(dy, dx)

                        Dim pushSpeed As Integer = 14
                        velocidad.X = pushSpeed * Math.Cos(angle)
                        velocidad.Y = pushSpeed * Math.Sin(angle)
                        RecibirDaño(10)
                        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Hand)
                    End If
                End If
                If objectRect.IntersectsWith(playerRect) Then
                    If Atacando = True Then
                        Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                        Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                        Dim angle As Double = Math.Atan2(dy, dx)
                        Enemigo2.Dispose()

                        Dim pushSpeed As Integer = 14
                        velocidad.X = pushSpeed * Math.Cos(angle)
                        velocidad.Y = pushSpeed * Math.Sin(angle)
                    End If
                End If
                If Enemigo2.Enabled Then
                    Dim direction As New Point(PictureBox1.Location.X - Enemigo2.Location.X, PictureBox1.Location.Y - Enemigo2.Location.Y)

                    Dim distance As Double = Math.Sqrt(direction.X ^ 2 + direction.Y ^ 2)

                    direction.X /= distance
                    direction.Y /= distance

                    Enemigo2.Left += CInt(direction.X * velocidadEnemigo)
                    Enemigo2.Top += CInt(direction.Y * velocidadEnemigo)
                End If

            End If

            '-------------------------------------Enemigo3
            If TypeOf control Is PictureBox AndAlso control.Name = "Enemigo3" Then
                Dim objectRect As Rectangle = New Rectangle(control.Location, control.Size)
                Dim playerRect As Rectangle = New Rectangle(PictureBox1.Location, PictureBox1.Size)
                If objectRect.IntersectsWith(playerRect) Then
                    If Atacando = False Then
                        Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                        Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                        Dim angle As Double = Math.Atan2(dy, dx)

                        Dim pushSpeed As Integer = 14
                        velocidad.X = pushSpeed * Math.Cos(angle)
                        velocidad.Y = pushSpeed * Math.Sin(angle)
                        RecibirDaño(10)
                        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Hand)
                    End If
                End If
                If objectRect.IntersectsWith(playerRect) Then
                    If Atacando = True Then
                        Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                        Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                        Dim angle As Double = Math.Atan2(dy, dx)
                        Enemigo3.Dispose()

                        Dim pushSpeed As Integer = 14
                        velocidad.X = pushSpeed * Math.Cos(angle)
                        velocidad.Y = pushSpeed * Math.Sin(angle)
                    End If
                End If
                If Enemigo3.Enabled Then
                    Dim direction As New Point(PictureBox1.Location.X - Enemigo3.Location.X, PictureBox1.Location.Y - Enemigo3.Location.Y)

                    Dim distance As Double = Math.Sqrt(direction.X ^ 2 + direction.Y ^ 2)

                    direction.X /= distance
                    direction.Y /= distance

                    Enemigo3.Left += CInt(direction.X * velocidadEnemigo)
                    Enemigo3.Top += CInt(direction.Y * velocidadEnemigo)
                End If

            End If
            '-------------------------------------Enemigo4
            If TypeOf control Is PictureBox AndAlso control.Name = "Enemigo4" Then
                Dim objectRect As Rectangle = New Rectangle(control.Location, control.Size)
                Dim playerRect As Rectangle = New Rectangle(PictureBox1.Location, PictureBox1.Size)
                If objectRect.IntersectsWith(playerRect) Then
                    If Atacando = False Then
                        Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                        Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                        Dim angle As Double = Math.Atan2(dy, dx)

                        Dim pushSpeed As Integer = 14
                        velocidad.X = pushSpeed * Math.Cos(angle)
                        velocidad.Y = pushSpeed * Math.Sin(angle)
                        RecibirDaño(10)
                        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Hand)
                    End If
                End If
                If objectRect.IntersectsWith(playerRect) Then
                    If Atacando = True Then
                        Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                        Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                        Dim angle As Double = Math.Atan2(dy, dx)
                        Enemigo4.Dispose()


                        Dim pushSpeed As Integer = 14
                        velocidad.X = pushSpeed * Math.Cos(angle)
                        velocidad.Y = pushSpeed * Math.Sin(angle)
                    End If
                End If
                If Enemigo4.Enabled Then
                    Dim direction As New Point(PictureBox1.Location.X - Enemigo4.Location.X, PictureBox1.Location.Y - Enemigo4.Location.Y)

                    Dim distance As Double = Math.Sqrt(direction.X ^ 2 + direction.Y ^ 2)

                    direction.X /= distance
                    direction.Y /= distance

                    Enemigo4.Left += CInt(direction.X * velocidadEnemigo)
                    Enemigo4.Top += CInt(direction.Y * velocidadEnemigo)
                End If

            End If
            '-------------------------------------Enemigo5
            If TypeOf control Is PictureBox AndAlso control.Name = "Enemigo5" Then
                Dim objectRect As Rectangle = New Rectangle(control.Location, control.Size)
                Dim playerRect As Rectangle = New Rectangle(PictureBox1.Location, PictureBox1.Size)
                If objectRect.IntersectsWith(playerRect) Then
                    If Atacando = False Then
                        Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                        Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                        Dim angle As Double = Math.Atan2(dy, dx)

                        Dim pushSpeed As Integer = 14
                        velocidad.X = pushSpeed * Math.Cos(angle)
                        velocidad.Y = pushSpeed * Math.Sin(angle)
                        RecibirDaño(10)
                        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Hand)
                    End If
                End If
                If objectRect.IntersectsWith(playerRect) Then
                    If Atacando = True Then
                        Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                        Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                        Dim angle As Double = Math.Atan2(dy, dx)
                        Enemigo5.Dispose()


                        Dim pushSpeed As Integer = 14
                        velocidad.X = pushSpeed * Math.Cos(angle)
                        velocidad.Y = pushSpeed * Math.Sin(angle)
                    End If
                End If
                If Enemigo5.Enabled Then
                    Dim direction As New Point(PictureBox1.Location.X - Enemigo5.Location.X, PictureBox1.Location.Y - Enemigo5.Location.Y)

                    Dim distance As Double = Math.Sqrt(direction.X ^ 2 + direction.Y ^ 2)

                    direction.X /= distance
                    direction.Y /= distance

                    Enemigo5.Left += CInt(direction.X * velocidadEnemigo)
                    Enemigo5.Top += CInt(direction.Y * velocidadEnemigo)
                End If

            End If
            '-------------------------------------Enemigo6
            If TypeOf control Is PictureBox AndAlso control.Name = "Enemigo6" Then
                Dim objectRect As Rectangle = New Rectangle(control.Location, control.Size)
                Dim playerRect As Rectangle = New Rectangle(PictureBox1.Location, PictureBox1.Size)
                If objectRect.IntersectsWith(playerRect) Then
                    If Atacando = False Then
                        Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                        Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                        Dim angle As Double = Math.Atan2(dy, dx)

                        Dim pushSpeed As Integer = 14
                        velocidad.X = pushSpeed * Math.Cos(angle)
                        velocidad.Y = pushSpeed * Math.Sin(angle)
                        RecibirDaño(10)
                        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Hand)
                    End If
                End If
                If objectRect.IntersectsWith(playerRect) Then
                    If Atacando = True Then
                        Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                        Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                        Dim angle As Double = Math.Atan2(dy, dx)
                        Enemigo6.Dispose()


                        Dim pushSpeed As Integer = 14
                        velocidad.X = pushSpeed * Math.Cos(angle)
                        velocidad.Y = pushSpeed * Math.Sin(angle)
                    End If
                End If
                If Enemigo6.Enabled Then
                    Dim direction As New Point(PictureBox1.Location.X - Enemigo6.Location.X, PictureBox1.Location.Y - Enemigo6.Location.Y)

                    Dim distance As Double = Math.Sqrt(direction.X ^ 2 + direction.Y ^ 2)

                    direction.X /= distance
                    direction.Y /= distance

                    Enemigo6.Left += CInt(direction.X * velocidadEnemigo)
                    Enemigo6.Top += CInt(direction.Y * velocidadEnemigo)
                End If

            End If
            '-------------------------------------Enemigo7
            If TypeOf control Is PictureBox AndAlso control.Name = "Enemigo7" Then
                Dim objectRect As Rectangle = New Rectangle(control.Location, control.Size)
                Dim playerRect As Rectangle = New Rectangle(PictureBox1.Location, PictureBox1.Size)
                If objectRect.IntersectsWith(playerRect) Then
                    If Atacando = False Then
                        Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                        Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                        Dim angle As Double = Math.Atan2(dy, dx)

                        Dim pushSpeed As Integer = 14
                        velocidad.X = pushSpeed * Math.Cos(angle)
                        velocidad.Y = pushSpeed * Math.Sin(angle)
                        RecibirDaño(10)
                        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Hand)
                    End If
                End If
                If objectRect.IntersectsWith(playerRect) Then
                    If Atacando = True Then
                        Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                        Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                        Dim angle As Double = Math.Atan2(dy, dx)
                        Enemigo7.Dispose()


                        Dim pushSpeed As Integer = 14
                        velocidad.X = pushSpeed * Math.Cos(angle)
                        velocidad.Y = pushSpeed * Math.Sin(angle)
                    End If
                End If
                If Enemigo7.Enabled Then
                    Dim direction As New Point(PictureBox1.Location.X - Enemigo7.Location.X, PictureBox1.Location.Y - Enemigo7.Location.Y)

                    Dim distance As Double = Math.Sqrt(direction.X ^ 2 + direction.Y ^ 2)

                    direction.X /= distance
                    direction.Y /= distance

                    Enemigo7.Left += CInt(direction.X * velocidadEnemigo)
                    Enemigo7.Top += CInt(direction.Y * velocidadEnemigo)
                End If

            End If
            '-------------------------------------Enemigo8
            If TypeOf control Is PictureBox AndAlso control.Name = "Enemigo8" Then
                Dim objectRect As Rectangle = New Rectangle(control.Location, control.Size)
                Dim playerRect As Rectangle = New Rectangle(PictureBox1.Location, PictureBox1.Size)
                If objectRect.IntersectsWith(playerRect) Then
                    If Atacando = False Then
                        Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                        Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                        Dim angle As Double = Math.Atan2(dy, dx)

                        Dim pushSpeed As Integer = 14
                        velocidad.X = pushSpeed * Math.Cos(angle)
                        velocidad.Y = pushSpeed * Math.Sin(angle)
                        RecibirDaño(10)
                        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Hand)
                    End If
                End If
                If objectRect.IntersectsWith(playerRect) Then
                    If Atacando = True Then
                        Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                        Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                        Dim angle As Double = Math.Atan2(dy, dx)
                        Enemigo8.Dispose()


                        Dim pushSpeed As Integer = 14
                        velocidad.X = pushSpeed * Math.Cos(angle)
                        velocidad.Y = pushSpeed * Math.Sin(angle)
                    End If
                End If
                If Enemigo8.Enabled Then
                    Dim direction As New Point(PictureBox1.Location.X - Enemigo8.Location.X, PictureBox1.Location.Y - Enemigo8.Location.Y)

                    Dim distance As Double = Math.Sqrt(direction.X ^ 2 + direction.Y ^ 2)

                    direction.X /= distance
                    direction.Y /= distance

                    Enemigo8.Left += CInt(direction.X * velocidadEnemigo)
                    Enemigo8.Top += CInt(direction.Y * velocidadEnemigo)
                End If

            End If
            '-------------------------------------Enemigo9
            If TypeOf control Is PictureBox AndAlso control.Name = "Enemigo9" Then
                Dim objectRect As Rectangle = New Rectangle(control.Location, control.Size)
                Dim playerRect As Rectangle = New Rectangle(PictureBox1.Location, PictureBox1.Size)
                If objectRect.IntersectsWith(playerRect) Then
                    If Atacando = False Then
                        Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                        Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                        Dim angle As Double = Math.Atan2(dy, dx)

                        Dim pushSpeed As Integer = 14
                        velocidad.X = pushSpeed * Math.Cos(angle)
                        velocidad.Y = pushSpeed * Math.Sin(angle)
                        RecibirDaño(10)
                        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Hand)
                    End If
                End If
                If objectRect.IntersectsWith(playerRect) Then
                    If Atacando = True Then
                        Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                        Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                        Dim angle As Double = Math.Atan2(dy, dx)
                        Enemigo9.Dispose()


                        Dim pushSpeed As Integer = 14
                        velocidad.X = pushSpeed * Math.Cos(angle)
                        velocidad.Y = pushSpeed * Math.Sin(angle)
                    End If
                End If
                If Enemigo9.Enabled Then
                    Dim direction As New Point(PictureBox1.Location.X - Enemigo9.Location.X, PictureBox1.Location.Y - Enemigo9.Location.Y)

                    Dim distance As Double = Math.Sqrt(direction.X ^ 2 + direction.Y ^ 2)

                    direction.X /= distance
                    direction.Y /= distance

                    Enemigo9.Left += CInt(direction.X * velocidadEnemigo)
                    Enemigo9.Top += CInt(direction.Y * velocidadEnemigo)
                End If

            End If
            '-------------------------------------Enemigo10
            If TypeOf control Is PictureBox AndAlso control.Name = "Enemigo10" Then
                Dim objectRect As Rectangle = New Rectangle(control.Location, control.Size)
                Dim playerRect As Rectangle = New Rectangle(PictureBox1.Location, PictureBox1.Size)
                If objectRect.IntersectsWith(playerRect) Then
                    If Atacando = False Then
                        Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                        Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                        Dim angle As Double = Math.Atan2(dy, dx)

                        Dim pushSpeed As Integer = 14
                        velocidad.X = pushSpeed * Math.Cos(angle)
                        velocidad.Y = pushSpeed * Math.Sin(angle)
                        RecibirDaño(10)
                        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Hand)
                    End If
                End If
                If objectRect.IntersectsWith(playerRect) Then
                    If Atacando = True Then
                        Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                        Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                        Dim angle As Double = Math.Atan2(dy, dx)
                        Enemigo10.Dispose()


                        Dim pushSpeed As Integer = 14
                        velocidad.X = pushSpeed * Math.Cos(angle)
                        velocidad.Y = pushSpeed * Math.Sin(angle)
                    End If
                End If
                If Enemigo10.Enabled Then
                    Dim direction As New Point(PictureBox1.Location.X - Enemigo10.Location.X, PictureBox1.Location.Y - Enemigo10.Location.Y)

                    Dim distance As Double = Math.Sqrt(direction.X ^ 2 + direction.Y ^ 2)

                    direction.X /= distance
                    direction.Y /= distance

                    Enemigo10.Left += CInt(direction.X * velocidadEnemigo)
                    Enemigo10.Top += CInt(direction.Y * velocidadEnemigo)
                End If

            End If
            '-------------------------------------Enemigo11
            If TypeOf control Is PictureBox AndAlso control.Name = "Enemigo11" Then
                Dim objectRect As Rectangle = New Rectangle(control.Location, control.Size)
                Dim playerRect As Rectangle = New Rectangle(PictureBox1.Location, PictureBox1.Size)
                If objectRect.IntersectsWith(playerRect) Then
                    If Atacando = False Then
                        Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                        Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                        Dim angle As Double = Math.Atan2(dy, dx)

                        Dim pushSpeed As Integer = 14
                        velocidad.X = pushSpeed * Math.Cos(angle)
                        velocidad.Y = pushSpeed * Math.Sin(angle)
                        RecibirDaño(10)
                        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Hand)
                    End If
                End If
                If objectRect.IntersectsWith(playerRect) Then
                    If Atacando = True Then
                        Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                        Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                        Dim angle As Double = Math.Atan2(dy, dx)
                        Enemigo11.Dispose()


                        Dim pushSpeed As Integer = 14
                        velocidad.X = pushSpeed * Math.Cos(angle)
                        velocidad.Y = pushSpeed * Math.Sin(angle)
                    End If
                End If
                If Enemigo11.Enabled Then
                    Dim direction As New Point(PictureBox1.Location.X - Enemigo11.Location.X, PictureBox1.Location.Y - Enemigo11.Location.Y)

                    Dim distance As Double = Math.Sqrt(direction.X ^ 2 + direction.Y ^ 2)

                    direction.X /= distance
                    direction.Y /= distance

                    Enemigo11.Left += CInt(direction.X * velocidadEnemigo)
                    Enemigo11.Top += CInt(direction.Y * velocidadEnemigo)
                End If

            End If
            '-------------------------------------Enemigo12
            If TypeOf control Is PictureBox AndAlso control.Name = "Enemigo12" Then
                Dim objectRect As Rectangle = New Rectangle(control.Location, control.Size)
                Dim playerRect As Rectangle = New Rectangle(PictureBox1.Location, PictureBox1.Size)
                If objectRect.IntersectsWith(playerRect) Then
                    If Atacando = False Then
                        Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                        Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                        Dim angle As Double = Math.Atan2(dy, dx)

                        Dim pushSpeed As Integer = 14
                        velocidad.X = pushSpeed * Math.Cos(angle)
                        velocidad.Y = pushSpeed * Math.Sin(angle)
                        RecibirDaño(10)
                        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Hand)
                    End If
                End If
                If objectRect.IntersectsWith(playerRect) Then
                    If Atacando = True Then
                        Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                        Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                        Dim angle As Double = Math.Atan2(dy, dx)
                        Enemigo12.Dispose()


                        Dim pushSpeed As Integer = 14
                        velocidad.X = pushSpeed * Math.Cos(angle)
                        velocidad.Y = pushSpeed * Math.Sin(angle)
                    End If
                End If
                If Enemigo12.Enabled Then
                    Dim direction As New Point(PictureBox1.Location.X - Enemigo12.Location.X, PictureBox1.Location.Y - Enemigo12.Location.Y)

                    Dim distance As Double = Math.Sqrt(direction.X ^ 2 + direction.Y ^ 2)

                    direction.X /= distance
                    direction.Y /= distance

                    Enemigo12.Left += CInt(direction.X * velocidadEnemigo)
                    Enemigo12.Top += CInt(direction.Y * velocidadEnemigo)
                End If

            End If
            '-------------------------------------Enemigo13
            If TypeOf control Is PictureBox AndAlso control.Name = "Enemigo13" Then
                Dim objectRect As Rectangle = New Rectangle(control.Location, control.Size)
                Dim playerRect As Rectangle = New Rectangle(PictureBox1.Location, PictureBox1.Size)
                If objectRect.IntersectsWith(playerRect) Then
                    If Atacando = False Then
                        Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                        Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                        Dim angle As Double = Math.Atan2(dy, dx)

                        Dim pushSpeed As Integer = 14
                        velocidad.X = pushSpeed * Math.Cos(angle)
                        velocidad.Y = pushSpeed * Math.Sin(angle)
                        RecibirDaño(10)
                        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Hand)
                    End If
                End If
                If objectRect.IntersectsWith(playerRect) Then
                    If Atacando = True Then
                        Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                        Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                        Dim angle As Double = Math.Atan2(dy, dx)
                        Enemigo13.Dispose()


                        Dim pushSpeed As Integer = 14
                        velocidad.X = pushSpeed * Math.Cos(angle)
                        velocidad.Y = pushSpeed * Math.Sin(angle)
                    End If
                End If
                If Enemigo13.Enabled Then
                    Dim direction As New Point(PictureBox1.Location.X - Enemigo13.Location.X, PictureBox1.Location.Y - Enemigo13.Location.Y)

                    Dim distance As Double = Math.Sqrt(direction.X ^ 2 + direction.Y ^ 2)

                    direction.X /= distance
                    direction.Y /= distance

                    Enemigo13.Left += CInt(direction.X * velocidadEnemigo)
                    Enemigo13.Top += CInt(direction.Y * velocidadEnemigo)
                End If

            End If
            '-------------------------------------Enemigo14
            If TypeOf control Is PictureBox AndAlso control.Name = "Enemigo14" Then
                Dim objectRect As Rectangle = New Rectangle(control.Location, control.Size)
                Dim playerRect As Rectangle = New Rectangle(PictureBox1.Location, PictureBox1.Size)
                If objectRect.IntersectsWith(playerRect) Then
                    If Atacando = False Then
                        Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                        Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                        Dim angle As Double = Math.Atan2(dy, dx)

                        Dim pushSpeed As Integer = 8
                        velocidad.X = pushSpeed * Math.Cos(angle)
                        velocidad.Y = pushSpeed * Math.Sin(angle)
                        RecibirDaño(10)
                        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Hand)
                    End If
                End If
                If objectRect.IntersectsWith(playerRect) Then
                    If Atacando = True Then
                        Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                        Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                        Dim angle As Double = Math.Atan2(dy, dx)
                        Enemigo14.Dispose()


                        Dim pushSpeed As Integer = 14
                        velocidad.X = pushSpeed * Math.Cos(angle)
                        velocidad.Y = pushSpeed * Math.Sin(angle)
                    End If
                End If
                If Enemigo14.Enabled Then
                    Dim direction As New Point(PictureBox1.Location.X - Enemigo14.Location.X, PictureBox1.Location.Y - Enemigo14.Location.Y)

                    Dim distance As Double = Math.Sqrt(direction.X ^ 2 + direction.Y ^ 2)

                    direction.X /= distance
                    direction.Y /= distance

                    Enemigo14.Left += CInt(direction.X * velocidadEnemigo)
                    Enemigo14.Top += CInt(direction.Y * velocidadEnemigo)
                End If

            End If
            '-------------------------------------Enemigo15
            If TypeOf control Is PictureBox AndAlso control.Name = "Enemigo15" Then
                Dim objectRect As Rectangle = New Rectangle(control.Location, control.Size)
                Dim playerRect As Rectangle = New Rectangle(PictureBox1.Location, PictureBox1.Size)
                If objectRect.IntersectsWith(playerRect) Then
                    If Atacando = False Then
                        Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                        Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                        Dim angle As Double = Math.Atan2(dy, dx)

                        Dim pushSpeed As Integer = 14
                        velocidad.X = pushSpeed * Math.Cos(angle)
                        velocidad.Y = pushSpeed * Math.Sin(angle)
                        RecibirDaño(10)
                        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Hand)
                    End If
                End If
                If objectRect.IntersectsWith(playerRect) Then
                    If Atacando = True Then
                        Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                        Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                        Dim angle As Double = Math.Atan2(dy, dx)
                        Enemigo15.Dispose()


                        Dim pushSpeed As Integer = 14
                        velocidad.X = pushSpeed * Math.Cos(angle)
                        velocidad.Y = pushSpeed * Math.Sin(angle)
                    End If
                End If
                If Enemigo15.Enabled Then
                    Dim direction As New Point(PictureBox1.Location.X - Enemigo15.Location.X, PictureBox1.Location.Y - Enemigo15.Location.Y)

                    Dim distance As Double = Math.Sqrt(direction.X ^ 2 + direction.Y ^ 2)

                    direction.X /= distance
                    direction.Y /= distance

                    Enemigo15.Left += CInt(direction.X * velocidadEnemigo)
                    Enemigo15.Top += CInt(direction.Y * velocidadEnemigo)
                End If

            End If
            '-------------------------------------Enemigo16
            If TypeOf control Is PictureBox AndAlso control.Name = "Enemigo16" Then
                Dim objectRect As Rectangle = New Rectangle(control.Location, control.Size)
                Dim playerRect As Rectangle = New Rectangle(PictureBox1.Location, PictureBox1.Size)
                If objectRect.IntersectsWith(playerRect) Then
                    If Atacando = False Then
                        Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                        Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                        Dim angle As Double = Math.Atan2(dy, dx)

                        Dim pushSpeed As Integer = 14
                        velocidad.X = pushSpeed * Math.Cos(angle)
                        velocidad.Y = pushSpeed * Math.Sin(angle)
                        RecibirDaño(10)
                        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Hand)
                    End If
                End If
                If objectRect.IntersectsWith(playerRect) Then
                    If Atacando = True Then
                        Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                        Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                        Dim angle As Double = Math.Atan2(dy, dx)
                        Enemigo16.Dispose()


                        Dim pushSpeed As Integer = 14
                        velocidad.X = pushSpeed * Math.Cos(angle)
                        velocidad.Y = pushSpeed * Math.Sin(angle)
                    End If
                End If
                If Enemigo16.Enabled Then
                    Dim direction As New Point(PictureBox1.Location.X - Enemigo16.Location.X, PictureBox1.Location.Y - Enemigo16.Location.Y)

                    Dim distance As Double = Math.Sqrt(direction.X ^ 2 + direction.Y ^ 2)

                    direction.X /= distance
                    direction.Y /= distance

                    Enemigo16.Left += CInt(direction.X * velocidadEnemigo)
                    Enemigo16.Top += CInt(direction.Y * velocidadEnemigo)
                End If

            End If
            '-------------------------------------Enemigo17
            If TypeOf control Is PictureBox AndAlso control.Name = "Enemigo17" Then
                Dim objectRect As Rectangle = New Rectangle(control.Location, control.Size)
                Dim playerRect As Rectangle = New Rectangle(PictureBox1.Location, PictureBox1.Size)
                If objectRect.IntersectsWith(playerRect) Then
                    If Atacando = False Then
                        Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                        Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                        Dim angle As Double = Math.Atan2(dy, dx)

                        Dim pushSpeed As Integer = 14
                        velocidad.X = pushSpeed * Math.Cos(angle)
                        velocidad.Y = pushSpeed * Math.Sin(angle)
                        RecibirDaño(10)
                        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Hand)
                    End If
                End If
                If objectRect.IntersectsWith(playerRect) Then
                    If Atacando = True Then
                        Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                        Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                        Dim angle As Double = Math.Atan2(dy, dx)
                        Enemigo17.Dispose()


                        Dim pushSpeed As Integer = 14
                        velocidad.X = pushSpeed * Math.Cos(angle)
                        velocidad.Y = pushSpeed * Math.Sin(angle)
                    End If
                End If
                If Enemigo17.Enabled Then
                    Dim direction As New Point(PictureBox1.Location.X - Enemigo17.Location.X, PictureBox1.Location.Y - Enemigo17.Location.Y)

                    Dim distance As Double = Math.Sqrt(direction.X ^ 2 + direction.Y ^ 2)

                    direction.X /= distance
                    direction.Y /= distance

                    Enemigo17.Left += CInt(direction.X * velocidadEnemigo)
                    Enemigo17.Top += CInt(direction.Y * velocidadEnemigo)
                End If

            End If
            '-------------------------------------Enemigo666
            If TypeOf control Is PictureBox AndAlso control.Name = "Enemigo666" Then
                Dim objectRect As Rectangle = New Rectangle(control.Location, control.Size)
                Dim playerRect As Rectangle = New Rectangle(PictureBox1.Location, PictureBox1.Size)
                If objectRect.IntersectsWith(playerRect) Then
                    If Atacando = False Then
                        Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                        Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                        Dim angle As Double = Math.Atan2(dy, dx)

                        Dim pushSpeed As Integer = 14
                        velocidad.X = pushSpeed * Math.Cos(angle)
                        velocidad.Y = pushSpeed * Math.Sin(angle)
                        RecibirDaño(10)
                        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Hand)
                    End If
                End If
                If objectRect.IntersectsWith(playerRect) Then
                    If Atacando = True Then
                        Dim dx As Integer = (playerRect.X + (playerRect.Width / 2)) - (objectRect.X + (objectRect.Width / 2))
                        Dim dy As Integer = (playerRect.Y + (playerRect.Height / 2)) - (objectRect.Y + (objectRect.Height / 2))
                        Dim angle As Double = Math.Atan2(dy, dx)
                        Enemigo666.Dispose()


                        Dim pushSpeed As Integer = 14
                        velocidad.X = pushSpeed * Math.Cos(angle)
                        velocidad.Y = pushSpeed * Math.Sin(angle)
                    End If
                End If
                If Enemigo666.Enabled Then
                    Dim direction As New Point(PictureBox1.Location.X - Enemigo666.Location.X, PictureBox1.Location.Y - Enemigo666.Location.Y)

                    Dim distance As Double = Math.Sqrt(direction.X ^ 2 + direction.Y ^ 2)

                    direction.X /= distance
                    direction.Y /= distance

                    Enemigo666.Left += CInt(direction.X * velocidadEnemigo)
                    Enemigo666.Top += CInt(direction.Y * velocidadEnemigo)
                End If

            End If
        Next
        If PictureBox1.Bounds.IntersectsWith(CuracionReal1.Bounds) Then
            RecibirCura(10)
            HPmensaje1.Visible = True
            curaIMAGEN.Visible = False
            Timer3.Start()
            CuracionReal1.Location = Corazon1.Location
            CuracionReal1.Dispose()
        End If
        If PictureBox1.Bounds.IntersectsWith(CuracionReal2.Bounds) Then
            RecibirCura(10)
            HPmensaje2.Visible = True
            Timer3.Start()
            curaIMAGEN2.Visible = False
            CuracionReal2.Location = Corazon1.Location
            CuracionReal2.Dispose()
            Beep()
        End If

    End Sub



    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        tiempo2 = tiempo2 + 1
        PictureBox1.Visible = False
        If tiempo2 = 300 Then
            Timer1.Start()
            Timer2.Stop()
            NivelCentro.Visible = False
            PictureBox1.Visible = True
            Enemigo5.Enabled = True
            Enemigo5.Visible = True
            Enemigo6.Enabled = True
            Enemigo6.Visible = True
            Enemigo7.Enabled = True
            Enemigo7.Visible = True
            Enemigo8.Enabled = True
            Enemigo8.Visible = True
            Enemigo9.Enabled = True
            Enemigo9.Visible = True
            Enemigo16.Enabled = True
            Enemigo16.Visible = True
            Enemigo17.Enabled = True
            Enemigo17.Visible = True
        End If
        If tiempo2 = 600 Then
            Timer1.Start()
            Timer2.Stop()
            Enemigo10.Enabled = True
            Enemigo10.Visible = True
            Enemigo11.Enabled = True
            Enemigo11.Visible = True
            Enemigo12.Enabled = True
            Enemigo12.Visible = True
            Enemigo13.Enabled = True
            Enemigo13.Visible = True
            Enemigo14.Enabled = True
            Enemigo14.Visible = True
            Enemigo15.Enabled = True
            Enemigo15.Visible = True
            Enemigo666.Enabled = True
            Enemigo666.Visible = True
            NivelCentro.Visible = False
            PictureBox1.Visible = True
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        My.Computer.Audio.Stop()
        PictureBox2.Visible = False
        PictureBox3.Visible = True
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        My.Computer.Audio.Play(My.Resources.zelda_shop_song, AudioPlayMode.BackgroundLoop)
        PictureBox3.Visible = False
        PictureBox2.Visible = True
    End Sub

    Private Sub Restart_Click(sender As Object, e As EventArgs) Handles Restart.Click
        Application.Restart()
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        tiempo3 = tiempo3 + 1
        If tiempo3 = 20 Then
            HPmensaje1.Visible = False
            HPmensaje2.Visible = False
            tiempo3 = 0
            Timer3.Stop()
        End If
    End Sub

End Class
