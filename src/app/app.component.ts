import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { ComponentesModule } from './componentes/componentes.module';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,ComponentesModule,RouterLink ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'tiendita';
}
